using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/ Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement")] 
    public float movementVelocity = 1f;
    public float maxHorizontalVelocity = 10f;
    public float friction = 0.4f;
    
    [Header("Jumping")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 3;

    [Header("Wall Jumps")]
    public Vector2 wallJumpVelocity = new Vector2(20, 20);
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);
    public float wallSlideVelocity = 3f;

    [Header("Check Variables")] 
    public float groundCheckRadius = 0.3f;
    public LayerMask whatIsGround;
    public float wallCheckDistance = 0.5f;

}
