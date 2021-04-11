using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

namespace Foundation.Unit.Player.Humanoid
{
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
            _controller = GetComponent<PlayerHumanoidController>();
        }

        protected override void InitVariables()
        {
            base.InitVariables();

            _animator = (_controller as PlayerHumanoidController).GetAnimator();
            _rigidbody = (_controller as PlayerHumanoidController).GetRigidbody();

            if (_fSprintSpeed != 0.0f)
            {
                _inputActions.Player.Sprint.performed += ctx => StartSprinting();
                _inputActions.Player.Sprint.canceled += ctx => StopSprinting();
            }
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

            if ((_controller as PlayerHumanoidController).CanMove)
            {
                if ((_movementInputVector.x != 0 || _movementInputVector.y != 0) && !(_controller as PlayerHumanoidController).IsLockedOntoEnemy)
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

            if ((_controller as PlayerHumanoidController).CanMove)
            {
                _movementInputVector = _inputActions.Player.Move.ReadValue<Vector2>();

                Vector2 movementOffset = _movementInputVector * (fCurrentSpeed * fSpeedModifier) * Time.fixedDeltaTime;
                Vector3 newPos = new Vector3(_rigidbody.position.x - movementOffset.y, _rigidbody.position.y, _rigidbody.position.z + movementOffset.x);
                _rigidbody.MovePosition(newPos);
            }
        }
    }
}
