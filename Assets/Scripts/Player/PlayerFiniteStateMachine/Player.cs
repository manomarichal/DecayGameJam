using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    
    [SerializeField] private PlayerData _playerData;
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public SpriteRenderer Sr { get; private set; }
    #endregion

    #region  Check Transforms

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _wallCheck;

    #endregion
    
    #region Other Variables
    public int FacingDirection { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 tempVelocity;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, _playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, _playerData, "Move");
        JumpState = new PlayerJumpState(this, StateMachine, _playerData, "Jump");
        InAirState = new PlayerInAirState(this, StateMachine, _playerData, "Jump");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, _playerData, "Jump");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, _playerData, "Jump");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, _playerData, "Jump");
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Rb = GetComponent<Rigidbody2D>();
        Sr = GetComponent<SpriteRenderer>();
        FacingDirection = 1;
        StateMachine.Initialize(IdleState);
    }

    // Update is called once per frame
    private void Update()
    {
        CurrentVelocity = Rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions
    public void SetVelocityX(float velocity)
    {
        tempVelocity.Set(velocity, CurrentVelocity.y);
        Rb.velocity = tempVelocity;
        CurrentVelocity = tempVelocity;
    }
    
    public void SetVelocityY(float velocity)
    {
        tempVelocity.Set(CurrentVelocity.x, velocity);
        Rb.velocity = tempVelocity;
        CurrentVelocity = tempVelocity;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        tempVelocity.Set(angle.x * velocity * direction, angle.y * velocity);
        Rb.velocity = tempVelocity;
        CurrentVelocity = tempVelocity;
    }
    #endregion
    
    #region Check Functions
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _playerData.groundCheckRadius, _playerData.whatIsGround);
    }
    
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {  
            FlipDirection();
        }
    }

    public bool IsTouchingWall()
    {
        Debug.DrawRay(_wallCheck.position,new Vector3(_playerData.wallCheckDistance*FacingDirection, 0, 0), Color.red, 5.0f);
        return Physics2D.Raycast(_wallCheck.position, new Vector3(FacingDirection, 0, 0), _playerData.wallCheckDistance, _playerData.whatIsGround);
    }
    #endregion

    #region Other Functions
    private void FlipDirection()
    {
        FacingDirection *= -1;
        Sr.flipX = !Sr.flipX;
    }
    #endregion

    #region Movement

    public void AddVelocityX(float velocity)
    {
        if (Mathf.Sign(velocity) == Math.Sign(CurrentVelocity.x) && Mathf.Abs(CurrentVelocity.x + velocity) > _playerData.maxHorizontalVelocity) return;
        
        tempVelocity.Set(CurrentVelocity.x + velocity, CurrentVelocity.y);
        Rb.velocity = tempVelocity;
        CurrentVelocity = tempVelocity;
    }

    #endregion

}
