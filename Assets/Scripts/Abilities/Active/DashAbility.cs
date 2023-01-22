using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[CreateAssetMenu]
public class DashAbility : ActiveAbility
{
    public PlayerStats stats;

    public float dashVelocity;

    public float maxDashCharges;

    public float dashRegenRate;

    public float Cost;

    public void Dash(Vector2 dashDirection, Rigidbody2D rb)
    {
        //PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        //Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();

        //rb.velocity = movement.movementInput.normalized * dashVelocity;

        //Camera.main.transform.DOComplete();
        //Camera.main.transform.DOShakePosition(.2f, .5f, 14, 90, false, true);
        rb.velocity = Vector2.zero;
        rb.velocity += dashDirection.normalized * (dashVelocity + 2*(stats.Agility.Value/100 * dashVelocity)) * stats.DashSpeed.Value ;

    }
}
