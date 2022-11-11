using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    [SerializeField] private float inputHoldtime = 0.1f;

    private float jumpInputStartTime;
    
    public bool jumpInput { get; private set; }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = (int)((RawMovementInput * Vector2.right).normalized.x);
        NormInputY = (int)((RawMovementInput * Vector2.up).normalized.y); 
    }
    
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GetComponent<Player>().Anim.SetBool("inair", true);
            jumpInput = true;
            jumpInputStartTime = Time.time;
        }
    }

    public void consumeJumpInput()
    {
        jumpInput = false;
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldtime)
        {
            jumpInput = false;
        };
    }
}
