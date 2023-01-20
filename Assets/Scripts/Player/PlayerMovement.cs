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
	
    [HideInInspector] public Vector2 movementInput;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private float runDeccelAmount;
    [SerializeField] private float lerpAmount;

    [SerializeField] private bool doConserveMomentum;
	[SerializeField] private bool isMoving;
	[SerializeField] private bool isDashing = false;
	[SerializeField] private bool isUsingDecel;
	[SerializeField] private Slider dashSlider;
    public bool isGrounded;
	public float nextLandingTime;
	private SpriteRenderer spriteRenderer;


	public DashAbility dashAbility;
	public float dashCharges;
	public float maxDashCharges;
	public float dashRegenRate;
	float activeTime;
	float cooldownTime;
	[SerializeField] AbilityState dashState = AbilityState.ready;

	void Start()
    {
		maxDashCharges = dashAbility.maxDashCharges;
		dashSlider.maxValue = maxDashCharges;
		dashSlider.value = dashCharges;
		dashRegenRate = dashAbility.dashRegenRate;
        rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		//acceleration = normalAcceleration;
	}

    void Update()
    {

		movementInput.x = Input.GetAxisRaw("Horizontal");
		movementInput.y = Input.GetAxisRaw("Vertical");

		//Dash Regen
		if (dashCharges < maxDashCharges)
		{
			dashCharges += Time.deltaTime * dashRegenRate;
			dashCharges = Mathf.Clamp(dashCharges, 0, maxDashCharges);
			dashSlider.value = dashCharges;
		}
		//Grounded if ungrounded time is up
		if (Time.time > nextLandingTime && !isGrounded)
        {
			isGrounded = true;
        }
		//Turn green if not grounded
        if (!isGrounded)
        {
			spriteRenderer.color = Color.green;
        } else if (dashState == AbilityState.active)
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
        if (!isDashing)
        {
            Run(lerpAmount);
        }
        if (isGrounded)
        {
            Dash();
        }
        
		
		
    }


    private void Run(float lerpAmount)
	{
		if (!isGrounded)
			movementInput = Vector2.zero;
		isMoving = (Mathf.Abs(movementInput.magnitude) > 0.01f);
		//Calculate the direction we want to move in and our desired velocity
		Vector2 targetSpeed = movementInput * (stats.MaxSpeed.Value + (stats.Agility.Value/100 * stats.MaxSpeed.Value));
		//We can reduce are control using Lerp() this smooths changes to are direction and speed
		targetSpeed = Vector2.Lerp(rb.velocity, targetSpeed, lerpAmount);

		#region Calculate AccelRate
		float accelRate;

        //Gets an acceleration value based on if we are accelerating (includes turning) 
        //or trying to decelerate (stop). As well as applying a multiplier if we're air borne.
        if (Mathf.Abs(targetSpeed.magnitude) > 0.01f)
        {
			accelRate = stats.Acceleration.Value * stats.Weight.Value;
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
        if (isGrounded && !isMoving)
        {
			rb.velocity *= stats.Friction.Value;
        }
	}


	void Dash()
	{
		switch (dashState)
		{
			case AbilityState.ready:
				if (Input.GetKey(KeyCode.Space) && dashCharges >= dashAbility.Cost)
				{
					dashAbility.Dash(movementInput, rb);
					dashState = AbilityState.active;
					activeTime = dashAbility.activeTime;
					dashCharges -= dashAbility.Cost;
					isDashing= true;
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
					cooldownTime = dashAbility.cooldownTime;
					isDashing = false;
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

