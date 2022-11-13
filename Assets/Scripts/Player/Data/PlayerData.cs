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
    public float gravityScale = 2f;

    [Header("Wall Jumps")]
    public Vector2 wallJumpVelocity = new Vector2(20, 20);
    public float wallSlideVelocity = 3f;
    public float wallSlideLetGoDelay = 0.1f;
    public float wallJumpTime = 0.2f;

    [Header("Check Variables")] 
    public float groundCheckRadius = 0.3f;
    public LayerMask whatIsGround;
    public float wallCheckDistance = 0.5f;

    [Header(("Combat Variables"))] 
    public GameObject acornPrefab;
    public GameObject acornSpawnPoint;
    public float rangedAttackCooldown = 1;

}
