using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputPC : MonoBehaviour
{
    public InputSO input;

    private void Update()
    {
        input.MovementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
