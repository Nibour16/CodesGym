using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class PlayerControls : MonoBehaviour
{
    protected CharacterController controller;
    protected Vector3 playerVelocity;
    protected bool groundedPlayer;

    protected InputManager inputManager;

    [Header("Player Movement")]
    [SerializeField] protected float playerSpeed = 2.0f;
    [SerializeField] protected float rotationSpeed = 4.0f;

    [Header("Player Jump")]
    [SerializeField] protected float jumpHeight = 1.0f;
    [SerializeField] protected float gravityValue = -9.81f;

    public abstract void PlayerMove();
    public abstract void PlayerJump();

    private void Start()
    {
        inputManager = InputManager.Instance;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMove();
        PlayerJump();
    }
}
