using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchingWallState : PlayerState
{
    protected bool isGrounded;

    protected bool isTouchingWall;
    
    protected int xInput;

    private float _xInputStartTime;
    private bool _trigger = false;
    
    private const float _triggerDelaytime = 0.1f;
    
    // Start is called before the first frame update
    public PlayerTouchingWallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandler.NormInputX;
        
        if (isGrounded)
        {
            stateMachine.ChangeState(player.IdleState);
            return;
        }
        
        if (!_trigger && xInput != player.FacingDirection)
        {
            _xInputStartTime = Time.time;
            _trigger = true;
        }
        else if (xInput == player.FacingDirection)
        {
            _trigger = false;
        }
        if (!isTouchingWall || (_trigger && Time.time - _xInputStartTime > playerData.wallSlideLetGoDelay))
        {
            stateMachine.ChangeState(player.InAirState);
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.IsTouchingWall();
    }
}
