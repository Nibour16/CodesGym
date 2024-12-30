using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageable", menuName = "Damageable", order = 1)]
public class DamageableSO : ScriptableObject
{
    public float maxHealth = 50.0f;
    [NonSerialized] public float health;

    public float defense;
}
