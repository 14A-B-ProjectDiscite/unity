using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerStats stats;
    public void StatChanged()
    {
        rb.mass = stats.Weight.Value;
    }
    private void Start()
    {
        stats.ResetStats();
    }
}
