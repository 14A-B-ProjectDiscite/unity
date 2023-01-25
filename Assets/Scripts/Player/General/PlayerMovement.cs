using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
	//public float normalAcceleration;
	//[SerializeField]
	//private float friction = 0.9f;
	///*[HideInInspector] */public float acceleration;
	
    [SerializeField] public InputSO input;
    [SerializeField] private Stat Agility;
    [SerializeField] private Stat MaxSpeed;
    [SerializeField] private Stat Acceleration;
    [SerializeField] private Stat Friction;
    [SerializeField] private Stat Weight;
    [SerializeField] private PlayerStates states;
    [SerializeField] private float runDeccelAmount;
    [SerializeField] private float lerpAmount;

    [SerializeField] private bool doConserveMomentum;

	public float nextLandingTime;
	private SpriteRenderer spriteRenderer;

	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		//acceleration = normalAcceleration;
	}

    void Update()
    {
		//Grounded if ungrounded time is up
		if (Time.time > nextLandingTime && !states.isGrounded)
        {
			states.isGrounded = true;
        }
		//Turn green if not grounded
        if (!states.isGrounded)
        {
			spriteRenderer.color = Color.green;
        }
        else if (states.isDashing)
        {
            spriteRenderer.color = Color.blue;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }

    }


	private void FixedUpdate()
    {
        if (!states.isDashing)
        {
            Run(lerpAmount);
        }
        
		
		
    }


    private void Run(float lerpAmount)
	{
		if (!states.isGrounded)
			input.MovementDirection = Vector2.zero;
		states.isMoving = (Mathf.Abs(input.MovementDirection.magnitude) > 0.01f);
		//Calculate the direction we want to move in and our desired velocity
		Vector2 targetSpeed = input.MovementDirection * (MaxSpeed.Statistic.Value + (Agility.Statistic.Value/100 * MaxSpeed.Statistic.Value));
		//We can reduce are control using Lerp() this smooths changes to are direction and speed
		targetSpeed = Vector2.Lerp(rb.velocity, targetSpeed, lerpAmount);

		#region Calculate AccelRate
		float accelRate;

        //Gets an acceleration value based on if we are accelerating (includes turning) 
        //or trying to decelerate (stop). As well as applying a multiplier if we're air borne.
        if (Mathf.Abs(targetSpeed.magnitude) > 0.01f)
        {
			accelRate = Acceleration.Statistic.Value * Weight.Statistic.Value;
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
			//Prevent any deceleration from happening
			//You could experiment with allowing for the player to slightly increae their speed whilst in this "state"
			accelRate = 0;
		}
		#endregion

		//Calculate difference between current velocity and desired velocity
		Vector2 speedDif = targetSpeed - rb.velocity;
        //Calculate force
        Vector2 movement = new Vector2();
        /*if (movementType == MovementType.Type1)
		{
			speedDif *= accelRate;

            movement.x = Mathf.Pow(speedDif.x, velPower) * Mathf.Sign(speedDif.x);
			movement.y = Mathf.Pow(speedDif.y, velPower) * Mathf.Sign(speedDif.y);*/
		//} else if (movementType == MovementType.Type2)
		//{
            movement = speedDif * accelRate;
        //}
		//Convert this to a vector and apply to rigidbody
		rb.AddForce(movement, ForceMode2D.Force);
		
		//If affected by explosion or moving, then do not apply friction
        if (states.isGrounded && !states.isMoving)
        {
			rb.velocity *= Friction.Statistic.Value;
        }
	}


	

}

