using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteraction : MonoBehaviour
{
    [SerializeField] private float radius = 2;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform sourceInteraction;

    [Range(0, 360)]
    [SerializeField] private float angleRange = 90;

    protected InputManager inputManager;
    protected bool isActOnce = false;

    public abstract void ExecuteInteraction(Transform ActionTarget);
    private void Update()
    {
        BaseAct();
    }

    private void BaseAct()
    {
        var targetsInViewRadius = Physics.OverlapSphere(sourceInteraction.position, radius, layerMask);
        inputManager = InputManager.Instance;

        for (var i = 0; i < targetsInViewRadius.Length; i++)
        {
            var target = targetsInViewRadius[i].transform;
            var directionToTarget = (target.position - sourceInteraction.position).normalized;

            //check if the target is within the spectrum
            if (Vector3.Angle(sourceInteraction.forward, directionToTarget) < angleRange / 2)
            {
                ExecuteInteraction(target);
                if (isActOnce)
                {
                    isActOnce = false;
                    break;
                }
            }
        }
    }
}
