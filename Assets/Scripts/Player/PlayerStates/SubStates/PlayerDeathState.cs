using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.Sm.death.Post(player.gameObject);
        player.Rb.constraints = RigidbodyConstraints2D.FreezeAll;
        
    }

    public void Respawn()
    {
        player.transform.position = player.respawnPosition;
        player.Rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        player.StateMachine.ChangeState(player.IdleState);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (Time.time - startTime > playerData.delayAfterDeath)
        {
            Respawn();
        }
    }
}
