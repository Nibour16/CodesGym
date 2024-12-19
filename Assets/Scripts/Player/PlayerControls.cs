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

    public abstract void Initialization();
    public abstract void ControllerAct();

    private void Start()
    {
        inputManager = InputManager.Instance;
        controller = GetComponent<CharacterController>();

        Initialization();
    }

    private void Update()
    {
        ControllerAct();
    }
}
