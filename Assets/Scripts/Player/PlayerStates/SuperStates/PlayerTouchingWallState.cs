using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchingWallState : PlayerState
{
    protected bool isGrounded;

    protected bool isTouchingWall;

    protected int xInput;
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
        }
        else if (!isTouchingWall || xInput != player.FacingDirection)
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
