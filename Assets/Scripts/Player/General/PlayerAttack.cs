using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameEvent attacked;
    [SerializeField] GameEvent primaryAttacked;
    [SerializeField] GameEvent secondaryAttacked;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PrimaryAttack();
        } 
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SecondaryAttack();
        }
    }
    public void PrimaryAttack()
    {
        attacked.Raise();
        primaryAttacked.Raise();
    }

    public void SecondaryAttack()
    {
        attacked.Raise();
        secondaryAttacked.Raise();
    }
}
