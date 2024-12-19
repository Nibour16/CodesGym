using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerControls
{
    [Header("Player Movement")]
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float rotationSpeed = 4.0f;
    [SerializeField] private float sprintSpeed = 6.0f;

    private float currentSpeed;

    [Header("Player Jump")]
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    public override void Initialization()
    {
        currentSpeed = walkSpeed;

        inputManager.playerInputs.Player.Sprint.performed += x => isSprint();
        inputManager.playerInputs.Player.Sprint.canceled += x => isWalk();
    }

    public override void ControllerAct()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        Vector2 movement = inputManager.playerInputs.Player.Movement.ReadValue<Vector2>();
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

        if (inputManager.playerInputs.Player.Jump.triggered && groundedPlayer)
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);

        playerVelocity.y += gravityValue * Time.deltaTime;
    }

    private void isSprint()
    {
        currentSpeed = sprintSpeed;
    }

    private void isWalk()
    {
        currentSpeed = walkSpeed;
    }
}
