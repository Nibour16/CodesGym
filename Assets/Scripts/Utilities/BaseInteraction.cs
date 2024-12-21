using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteraction : MonoBehaviour
{
    [SerializeField] private float radius = 2;
    [SerializeField] private LayerMask layerMask;

    [Range(0, 360)]
    [SerializeField] private float angle = 90;

    public abstract void ExecuteAction(Transform ActionTarget);
    private void Update()
    {
        BaseAct();
    }

    private void BaseAct()
    {
        var targetsInViewRadius = Physics.OverlapSphere(transform.position, radius, layerMask);

        for (var i = 0; i < targetsInViewRadius.Length; i++)
        {
            var target = targetsInViewRadius[i].transform;
            var directionToTarget = (target.position - transform.position).normalized;

            //check if the target is within the spectrum
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                ExecuteAction(target);
            }
        }
    }
}
