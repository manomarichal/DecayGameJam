using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(playerData.wallJumpVelocity.y);
        player.SetVelocityX(playerData.wallJumpVelocity.x * player.WallSlideState.SlideDirection *-1);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time - startTime > playerData.wallJumpTime)
        {
            stateMachine.ChangeState(player.InAirState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
