using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputPC : MonoBehaviour
{
    public Vector2Variable input;

    private void Update()
    {
        input.Value = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
