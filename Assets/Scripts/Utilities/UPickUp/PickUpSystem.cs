using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpSystem : MonoBehaviour
{
    [SerializeField] private string grabName;

    private float switchSwapTime = 0.001f;
    protected bool isPickedUp = false;

    public string getName()
    {
        return grabName;
    }
    protected void PickUp(GameObject grabbedObject)
    {
        Debug.Log(grabName);

        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        grabbedObject.transform.position = GrabPos.Instance.grabPos.position;
        grabbedObject.transform.rotation = GrabPos.Instance.grabPos.rotation;
        grabbedObject.transform.SetParent(GrabPos.Instance.grabPos);
        StartCoroutine(CheckSwap());
    }

    protected void Release(GameObject grabbedObject)
    {
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabbedObject.transform.SetParent(null);
        StartCoroutine(CheckSwap());
    }
    IEnumerator CheckSwap()
    {
        yield return new WaitForSeconds(switchSwapTime);
        isPickedUp ^= true;
        Debug.Log(isPickedUp);
    }
}
