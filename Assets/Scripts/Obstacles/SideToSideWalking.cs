using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSideWalking : MonoBehaviour
{
    public Transform sideRayOrigin;
    public Transform downRayOrigin;

    public float sideRaySize;
    public float downRaySize;

    public LayerMask whatIsGround;
    
    public float walkingSpeed;

    private bool _isTouchingGround;
    private bool _isTouchingWall;
    
    private int _direction = 1;

    private void Update()
    {
        // Debug.DrawRay(downRayOrigin.position, new Vector3(0, -5, 0), Color.blue, 2f);
        _isTouchingGround = Physics2D.Raycast(downRayOrigin.position, Vector2.down, downRaySize, whatIsGround);
        Debug.DrawRay(sideRayOrigin.position, new Vector3(sideRaySize, 0, 0), Color.blue, 0.1f);
        _isTouchingWall = Physics2D.Raycast(sideRayOrigin.position, Vector2.right*_direction, sideRaySize, whatIsGround);
        if (!_isTouchingGround || _isTouchingWall)
        {   
            _direction *= -1;
            
            var p = downRayOrigin.localPosition;
            downRayOrigin.localPosition = new Vector3(p.x * -1, p.y, p.z);

            p = sideRayOrigin.localPosition;
            sideRayOrigin.localPosition = new Vector3(p.x * -1, p.y, p.z);
        }
        else
        {
            transform.position += new Vector3(_direction*walkingSpeed*Time.deltaTime, 0);
        }
    }
}
