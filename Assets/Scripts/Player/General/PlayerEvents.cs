using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public Rigidbody2D rb;
    public Stat Weight;
    public void WeightChanged()
    {
        rb.mass = Weight.Statistic.Value;
    }

}
