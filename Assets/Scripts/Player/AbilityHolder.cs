using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public ActiveAbility ability;
    float activeTime;
    float cooldownTime;
    

    AbilityState dashState = AbilityState.ready;

    public KeyCode dashKey;

    void Update()
    {
        Dash();


    }

    void Dash()
    {
        switch (dashState)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(dashKey))
                {
                    ability.Activate(gameObject);
                    dashState = AbilityState.active;
                    activeTime = ability.activeTime;
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
                    cooldownTime = ability.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                break;
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    dashState = AbilityState.ready;
                }
            default:
                break;

        }
    }
}
