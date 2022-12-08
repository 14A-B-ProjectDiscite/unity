using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public float speed;
    void Update()
    {
        Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        LookatPosition(WorldPoint);
    }
    public void LookatPosition(Vector3 pos)
    {
        Vector3 Difference = pos - transform.position;
        Difference.Normalize();

        float RotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;
        //float targetz = Mathf.Lerp(transform.rotation.z, RotationZ, speed * Time.deltaTime );
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, RotationZ), speed * Time.deltaTime);
    }
}
