using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnTouchDeadly : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Deadly"))
        {
            _player.StateMachine.ChangeState(_player.DeathState);
        }
    }
}
