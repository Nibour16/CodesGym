using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTest : BasePickUp, IUsingItem
{
    public void UseItem()
    {
        Debug.Log("Nothing to do...");
    }
}
