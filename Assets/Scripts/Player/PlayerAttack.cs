using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : BaseInteraction
{
    [Header("Attack stats")]
    [SerializeField] private float baseDamage = 20.0f;
    [SerializeField] private float critical = 5.0f;
    [SerializeField] private float damMin = 2.0f;

    public override void ExecuteInteraction(Transform ActionTarget)
    {
        if (inputManager.GetAttackButton())
        {
            IDamageable iDamageable = ActionTarget.GetComponent<IDamageable>();
            iDamageable.Hit(baseDamage, critical, damMin);
        }
    }
}
