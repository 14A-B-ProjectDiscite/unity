using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    //public float normalAcceleration;
    //[SerializeField]
    //private float friction = 0.9f;
    ///*[HideInInspector] */public float acceleration;
    [HideInInspector] public Vector2 movementInput;
	[SerializeField] private float runMaxSpeed;
    [SerializeField] private float runAccelAmount;
    [SerializeField] private float runDeccelAmount;
    [SerializeField] private bool doConserveMomentum;
    [SerializeField] private float lerpAmount;
	[SerializeField] private float velPower;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //acceleration = normalAcceleration;
    }

    // Update is called once per frame
    void Update()
    {
		movementInput.x = Input.GetAxisRaw("Horizontal");
		movementInput.y = Input.GetAxisRaw("Vertical");
	}

    private void FixedUpdate()
    {
		Run(lerpAmount);
    }

 //   private void Move()
 //   {
	//	rb.velocity += movementInput * acceleration * Time.fixedDeltaTime;

	//	if (movementInput.magnitude < 0.01)
	//	{
	//		rb.velocity = rb.velocity * friction;
	//	}
	//}




    private void Run(float lerpAmount)
	{
		//Calculate the direction we want to move in and our desired velocity
		Vector2 targetSpeed = movementInput * runMaxSpeed;
		//We can reduce are control using Lerp() this smooths changes to are direction and speed
		targetSpeed = Vector2.Lerp(rb.velocity, targetSpeed, lerpAmount);

		#region Calculate AccelRate
		float accelRate;

        //Gets an acceleration value based on if we are accelerating (includes turning) 
        //or trying to decelerate (stop). As well as applying a multiplier if we're air borne.
        if (Mathf.Abs(targetSpeed.magnitude) > 0.01f)
        {
			accelRate = runAccelAmount;
        }
        else
        {
			accelRate = runDeccelAmount;
		}
			//accelRate = (Mathf.Abs(targetSpeed.magnitude) > 0.01f) ? runAccelAmount : runDeccelAmount;

		#endregion


		#region Conserve Momentum
		//We won't slow the player down if they are moving in their desired direction but at a greater speed than their maxSpeed
		if (doConserveMomentum && Mathf.Abs(rb.velocity.magnitude) > Mathf.Abs(targetSpeed.magnitude) && Mathf.Sign(rb.velocity.magnitude) == Mathf.Sign(targetSpeed.magnitude) && Mathf.Abs(targetSpeed.magnitude) > 0.01f)
		{
			//Prevent any deceleration from happening, or in other words conserve are current momentum
			//You could experiment with allowing for the player to slightly increae their speed whilst in this "state"
			accelRate = 0;
		}
		#endregion

		//Calculate difference between current velocity and desired velocity
		Vector2 speedDif = targetSpeed - rb.velocity;
		//Calculate force along x-axis to apply to thr player
		//Vector2 movement = new Vector2();
		//movement.x =  Mathf.Pow(speedDif.x * accelRate, velPower) * Mathf.Sign(speedDif.x);
		//movement.y =  Mathf.Pow(speedDif.y * accelRate, velPower) * Mathf.Sign(speedDif.y);
		Vector2 movement = speedDif * accelRate;

		//Convert this to a vector and apply to rigidbody
		rb.AddForce(movement, ForceMode2D.Force);

		/*
		 * For those interested here is what AddForce() will do
		 * rb.velocity = new Vector2(rb.velocity.magnitude + (Time.fixedDeltaTime  * speedDif * accelRate) / rb.mass, rb.velocity.y);
		 * Time.fixedDeltaTime is by default in Unity 0.02 seconds equal to 50 FixedUpdate() calls per second
		*/
	}
}
