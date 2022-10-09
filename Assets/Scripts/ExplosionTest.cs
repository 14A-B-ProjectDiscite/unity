using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTest : MonoBehaviour
{
    public float explosionRate;
    public float force;
    public float range;
    private float nextExplosionTime;
    private SpriteRenderer renderer;
    private Color red = Color.red;
    private Color blue = Color.blue;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
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
            col.GetComponent<Rigidbody2D>().AddForce((col.transform.position - transform.position) * force, ForceMode2D.Impulse);
        }
        nextExplosionTime = Time.time + explosionRate;
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        renderer.color = red;
        yield return new WaitForSeconds(.1f);
        renderer.color = blue;
    }
}
