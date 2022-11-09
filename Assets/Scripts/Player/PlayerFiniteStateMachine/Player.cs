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
    [SerializeField] private PlayerData _playerData;
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public SpriteRenderer Sr { get; private set; }
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

        IdleState = new PlayerIdleState(this, StateMachine, _playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, _playerData, "move");
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
    #endregion
    
    #region Check Functions
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {  
            FlipDirection();
            Debug.Log("flip!");
        }
    }
    #endregion

    #region Other Functions
    private void FlipDirection()
    {
        FacingDirection *= -1;
        Sr.flipX = !Sr.flipX;
    }
    #endregion

}