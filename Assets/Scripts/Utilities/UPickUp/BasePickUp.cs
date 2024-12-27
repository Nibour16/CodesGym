using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePickUp : PickUpSystem, IInteractable
{
    public void Interact()
    {
        if (!isPickedUp)
        {
            PickUp(gameObject);
        }
    }

    private void Update()
    {
        if (isPickedUp && InputManager.Instance.GetInteractButton())
        {
            PutDownObj();
        }
    }

    private void PutDownObj()
    {
        Release(gameObject);
    }
}
