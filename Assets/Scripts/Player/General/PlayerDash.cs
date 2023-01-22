using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] AbilityState dashState = AbilityState.ready;
    [SerializeField] InputSO input;
    [SerializeField] DashAbility currentAbility;
    [SerializeField] PlayerStates states;
    public float dashRegenRate;
    public float maxDashCharges;

    private float cooldownTime;
    public float dashCharges;
    public float activeTime;

    private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        DashChanged();
    }

    // Update is called once per frame
    void Update()
    {
        //Dash Regen
        if (dashCharges < maxDashCharges)
        {
            dashCharges += Time.deltaTime * dashRegenRate;
            dashCharges = Mathf.Clamp(dashCharges, 0, maxDashCharges);
            //dashSlider.value = dashCharges;
        }
    }

    private void FixedUpdate()
    {
        if (states.isGrounded)
        {
            Dash();
        }
        
    }

    private void DashChanged()
    {
        maxDashCharges = currentAbility.maxDashCharges;
        dashRegenRate = currentAbility.dashRegenRate;
    }

    void Dash()
    {
        
        switch (dashState)
        {
            case AbilityState.ready:
                if (Input.GetKey(KeyCode.Space) && dashCharges >= currentAbility.Cost)
                {
                    currentAbility.Dash(input.MovementDirection, rb);
                    dashState = AbilityState.active;
                    activeTime = currentAbility.activeTime;
                    dashCharges -= currentAbility.Cost;
                    states.isDashing = true;
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    dashState = AbilityState.cooldown;
                    cooldownTime = currentAbility.cooldownTime;
                    states.isDashing = false;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    dashState = AbilityState.ready;
                }
                break;

            default:
                break;

        }
    }
}
