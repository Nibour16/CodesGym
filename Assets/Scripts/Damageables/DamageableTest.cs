using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableTest : BaseDamageable, IDamageable
{
    public void Hit(float damage, float critical, float damMin)
    {
        GetDamage(damage, critical, damMin);
    }
}
