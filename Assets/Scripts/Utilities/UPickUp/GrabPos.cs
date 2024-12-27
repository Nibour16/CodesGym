using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPos : MonoBehaviour
{
    private static GrabPos _instance;

    public Transform grabPos;

    public static GrabPos Instance
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
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }
}
