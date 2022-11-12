using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public int SlideDirection { private set; get; }
    // Start is called before the first frame update
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        SlideDirection = player.FacingDirection;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.SetVelocityY(-playerData.wallSlideVelocity);
        player.SetVelocityX(0);

        if (player.InputHandler.jumpInput && !isExitingState)
        {
            player.InputHandler.ConsumeJumpInput();
            stateMachine.ChangeState(player.WallJumpState);
        }
    }
}
