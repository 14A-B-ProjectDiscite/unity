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
	public DashAbility dashAbility;
	public float dashCharges;
	public float maxDashCharges;
	public float dashRegenRate;

	public MovementType movementType;
    [HideInInspector] public Vector2 movementInput;
	[SerializeField] private float runMaxSpeed;
    [SerializeField] private float runAccelAmount;
    [SerializeField] private float runDeccelAmount;
    [SerializeField] private float lerpAmount;
	[SerializeField] private float velPower;
	[SerializeField] private float friction;
    [SerializeField] private bool doConserveMomentum;
	[SerializeField] private bool isMoving;
	[SerializeField] private bool isUsingDecel;
    public bool isGrounded;
	public float nextLandingTime;
	private SpriteRenderer spriteRenderer;


	// Start is called before the first frame update
	void Start()
    {
		
        rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		//acceleration = normalAcceleration;
	}

    // Update is called once per frame
    void Update()
    {
		movementInput.x = Input.GetAxisRaw("Horizontal");
		movementInput.y = Input.GetAxisRaw("Vertical");

        if (Time.time > nextLandingTime && !isGrounded)
        {
			isGrounded = true;
        }

        if (isGrounded)
        {
			spriteRenderer.color = Color.red;
        }
        else
        {
			spriteRenderer.color = Color.green;
		}

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
		if (!isGrounded)
			movementInput = Vector2.zero;
		isMoving = (Mathf.Abs(movementInput.magnitude) > 0.01f);
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
			isUsingDecel = false;
        }
        else
        {
			isUsingDecel = true;
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
        if (movementType == MovementType.Type1)
		{
			speedDif *= accelRate;

            movement.x = Mathf.Pow(speedDif.x, velPower) * Mathf.Sign(speedDif.x);
			movement.y = Mathf.Pow(speedDif.y, velPower) * Mathf.Sign(speedDif.y);
		} else if (movementType == MovementType.Type2)
		{
            movement = speedDif * accelRate;
        }

        

		//Convert this to a vector and apply to rigidbody
		rb.AddForce(movement, ForceMode2D.Force);
		
		//If affected by explosion or moving, then do not apply friction
        if (isGrounded && !isMoving)
        {
			rb.velocity *= friction;
        }

		
		
	}
	
}
public enum MovementType
{
    Type1,
    Type2
}
