using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMovingPlatform : MonoBehaviour
{
    public float acceleration = 3f;
    public float maxAcceleration = 3f;
    public float moveDistance = 10f;

    private float _velocity;
    private int _direction = 1;
    private float _leftX;
    private float _rightX;
    private float _startX;
    private bool _isTouchingPlayer;
    private GameObject _player;

    private void Start()
    {
        _startX = transform.position.x;
        _leftX = _startX;
        _rightX = _startX + moveDistance;
        _isTouchingPlayer = false;
    }

    private void Move()
    {
        var movement = new Vector3(_velocity * Time.deltaTime, 0, 0);
        transform.position += movement;
        
        // move player
        if (_isTouchingPlayer)
        {
            _player.transform.position += movement;
        }
    }

    private void Accelerate()
    {
        if ((_direction == 1 && _velocity < maxAcceleration) || (_direction == -1 && _velocity > -maxAcceleration))
        {
            _velocity += acceleration*_direction;
        }
    }

    private void FlipDirection()
    {
        _direction *= -1;
        // update start & end points since value might be changed during runtime
        _leftX = _startX;
        _rightX = _startX + moveDistance;
    }
    private void Update()
    {
        Move();
        
        if ((_direction == 1 && transform.position.x >= _rightX) || (_direction == -1 && transform.position.x <= _leftX))
        {
            FlipDirection();
        }

        Accelerate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        
        if (collision.collider.CompareTag("Player"))
        {
            _player = collision.collider.gameObject;
            _isTouchingPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("exit");

        if (other.collider.CompareTag("Player"))
        {
            _isTouchingPlayer = false;
        }
    }
}
