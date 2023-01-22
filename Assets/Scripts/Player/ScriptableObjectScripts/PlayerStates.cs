using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerStates : ScriptableObject
{
    public bool isDashing;
    public bool isGrounded;
    public bool isDamaged;
    public bool isIdle;
    public bool isMoving;
}
