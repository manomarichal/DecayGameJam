using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRangedAttackState : PlayerAbilityState
{
    public PlayerRangedAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        GameObject acorn = GameObject.Instantiate(playerData.acornPrefab, player.transform.position, Quaternion.identity);
        acorn.GetComponent<Acorn>().Initialize(player.FacingDirection);
        isAbilityDone = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
