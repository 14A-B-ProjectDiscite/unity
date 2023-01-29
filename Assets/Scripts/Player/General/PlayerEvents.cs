using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public Rigidbody2D rb;
    public Stat Weight;
    public FloatVariable energy;
    public FloatVariable maxEnergy;

    public void WeightChanged()
    {
        rb.mass = Weight.Statistic.Value;
    }
    public void RandomEnergy()
    {
        float a = Random.Range(-5, 5);
        float b = energy.Value + a;
        float c = Mathf.Max(b, maxEnergy.Value);

        energy.Value = c;

    }
}
