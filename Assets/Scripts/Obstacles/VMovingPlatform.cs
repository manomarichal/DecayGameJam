using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMovingPlatform : MonoBehaviour
{
    public float acceleration = 3f;
    public float maxAcceleration = 3f;
    public float moveDistance = 10f;

    private float _velocity;
    private int _direction = 1;
    private float _bottomY;
    private float _topY;
    private float _startY;
    private bool _isTouchingPlayer;
    private GameObject _player;

    private void Start()
    {
        _startY = transform.position.y;
        _bottomY = _startY;
        _topY = _startY + moveDistance;
        _isTouchingPlayer = false;
    }

    private void Move()
    {
        var movement = new Vector3(0,_velocity*Time.deltaTime, 0);
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
    }
    private void FixedUpdate()
    {
        Move();
        if ((_direction == 1 && transform.position.y >= _topY) || (_direction == -1 && transform.position.y <= _bottomY))
        {
            FlipDirection();
        }
        Accelerate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _player = collision.collider.gameObject;
            _isTouchingPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            _isTouchingPlayer = false;
        }
    }
}
