using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PrimaryAttack();
        } else if (Input.GetKeyDown(KeyCode.Mouse1))
        {

        }
    }
    public void PrimaryAttack()
    {

    }

    public void SecondaryAttack()
    {

    }
}
