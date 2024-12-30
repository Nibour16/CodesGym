using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDamageable : MonoBehaviour
{
    [SerializeField] private DamageableSO damageableRef;
    private DamageCalculator damageCalculator;

    private void Start()
    {
        damageableRef.health = damageableRef.maxHealth;
    }

    protected void GetDamage(float baseDamage, float critical, float baseDamMin)
    {
        damageCalculator = new DamageCalculator();
        damageCalculator.SetCalculatorParams(baseDamage, critical, baseDamMin, damageableRef.defense);

        damageableRef.health -= damageCalculator.GetDamageCalculated();
        if (damageableRef.health <= 0)
        {
            Debug.Log("Oh no! I died.");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"Ouch! I only have {damageableRef.health} left!!");
        }
    }
}
