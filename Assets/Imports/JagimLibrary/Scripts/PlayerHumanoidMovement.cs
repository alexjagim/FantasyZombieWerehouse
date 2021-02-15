using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

[RequireComponent(typeof(PlayerHumanoidController))]
public class PlayerHumanoidMovement : PlayerMovement
{
    private Animator _animator;

    private Vector2 _movementInputVector;

    [SerializeField, LabelText("Sprint Speed")]
    private float _fSprintSpeed = 0.0f;

    public bool IsSprinting
    {
        get
        {
            return fCurrentSpeed == _fSprintSpeed;
        }
    }

    protected override void InitController()
    {
        controller = GetComponent<PlayerHumanoidController>();
    }

    protected override void InitVariables()
    {
        base.InitVariables();

        _animator = GetComponent<Animator>();

        _inputActions.Player.Sprint.performed += ctx => StartSprinting();
        _inputActions.Player.Sprint.canceled += ctx => StopSprinting();
    }

    private void StartSprinting()
    {
        _animator.SetBool("bRunning", true);
        fCurrentSpeed = _fSprintSpeed;
    }

    private void StopSprinting()
    {
        _animator.SetBool("bRunning", false);
        fCurrentSpeed = fMovementSpeed;
    }

    protected override void UpdateAnimations()
    {
        base.UpdateAnimations();

        if((controller as PlayerHumanoidController).CanMove)
        {
            if ((_movementInputVector.x != 0 || _movementInputVector.y != 0) && !(controller as PlayerHumanoidController).IsLockedOntoEnemy)
            {
                _animator.SetBool("bWalking", true);
            }
            else
            {
                _animator.SetBool("bWalking", false);
            }
        }
        else
        {
            _animator.SetBool("bWalking", false);
        }
    }

    protected override void UpdateMovement()
    {
        base.UpdateMovement();

        if((controller as PlayerHumanoidController).CanMove)
        {
            _movementInputVector = _inputActions.Player.Move.ReadValue<Vector2>();

            Vector2 movementOffset = _movementInputVector * fCurrentSpeed * Time.fixedDeltaTime;
            Vector3 newPos = new Vector3(_rigidbody.position.x + movementOffset.x, _rigidbody.position.y, _rigidbody.position.z + movementOffset.y);
            _rigidbody.MovePosition(newPos);
        }
    }
}
