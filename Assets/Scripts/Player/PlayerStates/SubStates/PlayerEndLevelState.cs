using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndLevelState : PlayerState
{
    // Start is called before the first frame update
    public PlayerEndLevelState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        player.SetVelocityX(1.5f);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.CheckIfGrounded())
        {
            player.Anim.Play("Move");
        }
        else
        {
            player.Anim.Play("Jump");
        }
    }
}
