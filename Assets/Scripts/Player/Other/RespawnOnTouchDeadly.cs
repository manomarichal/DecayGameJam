using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnTouchDeadly : MonoBehaviour
{
    public Vector3 respawnPosition;
    private Player _player;
    private void Start()
    {
        respawnPosition = transform.position;
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Deadly"))
        {
            transform.position = respawnPosition;
            _player.StateMachine.ChangeState(_player.IdleState);
        }
    }
}
