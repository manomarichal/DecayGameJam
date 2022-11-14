using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    private RigidbodyConstraints2D _playerConstraints;
    public PlayerDeathState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _playerConstraints = player.Rb.constraints;
        player.Rb.constraints = RigidbodyConstraints2D.FreezeAll;
        
    }

    public void Respawn()
    {
        player.transform.position = player.respawnPosition;
        player.Rb.constraints = _playerConstraints;
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
