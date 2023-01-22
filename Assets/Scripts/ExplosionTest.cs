using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTest : MonoBehaviour
{
    [SerializeField] private PlayerStates states;
    [SerializeField] private float explosionRate;
    [SerializeField] private float force;
    [SerializeField] private float range;
    [SerializeField] private float knockback;
    private float nextExplosionTime;
    private SpriteRenderer spriteRenderer;
    private Color red = Color.red;
    private Color blue = Color.blue;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        nextExplosionTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextExplosionTime)
        {
            Explosion();
        }
    }

    void Explosion()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D col in colls)
        {
            //full vector that is range length, in the direction of the targer
            Vector2 direction = (col.transform.position - transform.position).normalized * range;
            Vector2 targetVector = col.transform.position - transform.position;
            Vector2 Force =  (direction - targetVector) * force;
            
            PlayerMovement movementScript = col.GetComponent<PlayerMovement>();
            if (movementScript != null)
            {
                states.isGrounded = false;
                Rigidbody2D thisRigidbody = col.GetComponent<Rigidbody2D>();
                if (thisRigidbody != null)
                {
                    thisRigidbody.AddForce(Force, ForceMode2D.Impulse);
                    movementScript.nextLandingTime = Time.time + (knockback / thisRigidbody.mass) * Force.magnitude;
                }
                
            }
            else
            {
                Rigidbody2D thisRigidbody = col.GetComponent<Rigidbody2D>();
                if (thisRigidbody != null)
                {
                    thisRigidbody.AddForce(Force, ForceMode2D.Impulse);
                }
            }
            
            
        }
        nextExplosionTime = Time.time + explosionRate;
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        spriteRenderer.color = red;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = blue;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
