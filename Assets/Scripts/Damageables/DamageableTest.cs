using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableTest : BaseDamageable, IDamageable
{
    public void Hit(float damage)
    {
        GetDamage(damage);
    }
}
