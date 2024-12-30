using System;
using UnityEngine;

public class DamageCalculator
{
    private float attacker_atk;
    private float attacker_critical;
    private float attacker_damMin;
    private float target_def;

    public void SetCalculatorParams(float atk, float critical, float damMin, float def)
    {
        attacker_atk = atk;
        attacker_critical = critical;
        attacker_damMin = damMin;
        target_def = def;
    }

    public float GetDamageCalculated()
    {
        return DamageCalculation();
    }

    private float DamageCalculation()
    {
        float result = Mathf.Clamp(attacker_atk - target_def, attacker_damMin, attacker_atk);

        if (result < 0)
            return 0;

        if (target_def - attacker_atk > attacker_critical)
        {
            result = Mathf.Clamp(attacker_damMin - (target_def - attacker_atk - attacker_critical), 0, attacker_damMin);
        }
        result = UnityEngine.Random.Range(result*0.85f, result * 1.15f);
        result = (float)Math.Round(result * 2, MidpointRounding.AwayFromZero) / 2;

        return result;
    }
}
