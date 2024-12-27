using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDamageable : MonoBehaviour
{
    [SerializeField] private float health = 3.0f;

    protected void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Oh no! I died.");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"Ouch! I only have {health} left!!");
        }
    }
}
