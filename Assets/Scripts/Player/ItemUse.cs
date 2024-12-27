using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    private void Update()
    {
        if (GrabPos.Instance.grabPos.GetComponentInChildren<IUsingItem>() != null && InputManager.Instance.GetItemUseButton())
        {
            IUsingItem iUsingItem = GrabPos.Instance.grabPos.GetComponentInChildren<IUsingItem>();
            iUsingItem.UseItem();
        }
    }
}
