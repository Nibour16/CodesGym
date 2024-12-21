using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : BaseInteraction
{
    public override void ExecuteAction(Transform ActionTarget)
    {
        InputManager inputManager = InputManager.Instance;

        if (inputManager.GetInteractButton())
        {
            IInteractable iInteractable = ActionTarget.GetComponent<IInteractable>();
            iInteractable.Interact();
        }
    }
}
