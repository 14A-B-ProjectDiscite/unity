using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float normalAcceleration;
    /*[HideInInspector] */public float acceleration;
    [HideInInspector] public Vector2 movementInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        acceleration = normalAcceleration;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Input = new Vector2();
    }

    private void FixedUpdate()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity += movementInput * acceleration * Time.fixedDeltaTime;

        //if (movementInput.magnitude < 0.01)
        //{
        //    rb.velocity = Vector2.zero;
        //}
    }
}
