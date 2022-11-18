using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    // Start is called before the first frame update
    private bool jumpInput;
    private int xInput;
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.jumpInput;
        
        if (player.CheckIfGrounded() && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
            player.InputHandler.ConsumeJumpInput();
        }
        else if (player.IsTouchingWall() && xInput == player.FacingDirection && player.CurrentVelocity.y <= 0)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
        else if (player.InputHandler.RangedAttackInput)
        {
            player.RangedAttack();
            player.InputHandler.ConsumeRangedAttackInput();
        }
        else
        {
            player.CheckIfShouldFlip(xInput);
            player.AddVelocityX(playerData.movementVelocity * xInput);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }
}
