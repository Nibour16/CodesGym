using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : BaseInteraction
{
    [SerializeField] private float attackDamage = 1.0f;
    
    public override void ExecuteInteraction(Transform ActionTarget)
    {
        if (inputManager.GetAttackButton())
        {
            IDamageable iDamageable = ActionTarget.GetComponent<IDamageable>();
            iDamageable.Hit(attackDamage);
        }
    }
}
