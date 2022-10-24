using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class DashAbility : ActiveAbility
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();

        rb.velocity = movement.movementInput.normalized * dashVelocity;
    }
}
