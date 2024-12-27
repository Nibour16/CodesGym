using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : BaseInteraction
{
    public override void ExecuteInteraction(Transform ActionTarget)
    {
        if (inputManager.GetInteractButton())
        {
            IInteractable iInteractable = ActionTarget.GetComponent<IInteractable>();
            iInteractable.Interact();
            isActOnce = true;
        }
    }
}
