using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerControls
{
    public override void PlayerMove()
    {
        Vector2 movement = inputManager.playerInputs.Player.Movement.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

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

    public override void PlayerJump()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        if (inputManager.playerInputs.Player.Jump.triggered && groundedPlayer)
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);

        playerVelocity.y += gravityValue * Time.deltaTime;
    }


}
