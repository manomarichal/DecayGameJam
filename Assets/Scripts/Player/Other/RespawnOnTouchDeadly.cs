using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnTouchDeadly : MonoBehaviour
{
    public Player player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Deadly"))
        {
            player.StateMachine.ChangeState(player.DeathState);
        }
    }
}
