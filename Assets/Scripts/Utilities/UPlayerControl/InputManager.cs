using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInputs playerInputs;

    private static InputManager _instance;

    #region Instance Setup
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }
    #endregion

    #region Player Actions
    public Vector2 GetPlayerMovement()
    {
        return playerInputs.Player.Movement.ReadValue<Vector2>();
    }

    public bool GetPlayerJump()
    {
        return playerInputs.Player.Jump.triggered;
    }

    public InputAction GetPlayerSprint()
    {
        return playerInputs.Player.Sprint;
    }

    public bool GetInteractButton()
    {
        return playerInputs.Player.Interact.triggered;
    }

    public bool GetAttackButton()
    {
        return playerInputs.Player.Attack.triggered;
    }

    public bool GetItemUseButton()
    {
        return playerInputs.Player.ItemUse.triggered;
    }
    #endregion
}
