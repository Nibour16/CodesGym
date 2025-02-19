using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    #region Variables
    [Header("Player Movement")]
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float rotationSpeed = 4.0f;
    [SerializeField] private float sprintSpeed = 6.0f;

    [Header("Player Jump")]
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    [Header("Non-Serialized Variables")]
    private float currentSpeed;
    protected Vector3 playerVelocity;
    protected bool groundedPlayer;
    #endregion

    #region Overrided Methods
    public override void Initialization()
    {
        currentSpeed = walkSpeed;

        inputManager.GetPlayerSprint().performed += x => isSprint();
        inputManager.GetPlayerSprint().canceled += x => isWalk();
    }

    public override void ControllerAct()
    {
        Movement();
        Jump();
    }
    #endregion

    #region Player Action
    private void Movement()
    {
        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0, movement.y);

        controller.Move(move * Time.deltaTime * currentSpeed);

        if (move != Vector3.zero)
            gameObject.transform.forward = move;

        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void Jump()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        if (inputManager.GetPlayerJump() && groundedPlayer)
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);

        playerVelocity.y += gravityValue * Time.deltaTime;
    }
    #endregion

    #region state Check
    private void isSprint()
    {
        currentSpeed = sprintSpeed;
    }

    private void isWalk()
    {
        currentSpeed = walkSpeed;
    }
    #endregion
}
