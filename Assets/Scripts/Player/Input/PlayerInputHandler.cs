using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    [SerializeField] private float inputHoldtime = 0.1f;
    
    #region Input Variables
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool RangedAttackInput { get; private set; }
    public bool jumpInput { get; private set; }
    #endregion
    
    #region Input Timer Variables
    
    private float jumpInputStartTime;
    private float rangedAttackInputStartTime;
    
    #endregion
    
    #region Input Functions
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
            jumpInput = true;
            jumpInputStartTime = Time.time;
        }
    }

    public void OnRangedAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RangedAttackInput = true;
            rangedAttackInputStartTime = Time.time;
        }
    }
    
    #endregion

    #region Consume Input Functions

    public void ConsumeJumpInput()
    {
        jumpInput = false;
    }

    public void ConsumeRangedAttackInput()
    {
        RangedAttackInput = false;
    }

    #endregion

    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    #region Check Input Functions

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldtime)
        {
            jumpInput = false;
        };
    }
    
    private void CheckRangedAttackInputHoldTime()
    {
        if (Time.time >= rangedAttackInputStartTime + inputHoldtime)
        {
            RangedAttackInput = false;
        };
    }

    #endregion
  

}
