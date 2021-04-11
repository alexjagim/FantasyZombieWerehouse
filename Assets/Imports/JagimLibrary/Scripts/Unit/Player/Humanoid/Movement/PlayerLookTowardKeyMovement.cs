using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Unit.Player.Humanoid.Movement
{
    [RequireComponent(typeof(PlayerHumanoidController))]
    public class PlayerLookTowardKeyMovement : MonoBehaviour
    {
        private PlayerHumanoidController _playerController;
        private PlayerInputActions _inputActions;
        private Vector2 _movementInputVector;

        // Start is called before the first frame update
        void Start()
        {
            _playerController = GetComponent<PlayerHumanoidController>();
            _inputActions = _playerController.GetInputActions();
        }

        // Update is called once per frame
        void Update()
        {
            if (_playerController.CanRotate)
            {
                _movementInputVector = _inputActions.Player.Move.ReadValue<Vector2>();

                if ((_movementInputVector.x != 0 || _movementInputVector.y != 0) && !_playerController.IsLockedOntoEnemy)
                {
                    Vector3 rot = new Vector3(-_movementInputVector.y, 0.0f, _movementInputVector.x);
                    transform.rotation = Quaternion.LookRotation(rot);
                }
            }
        }
    }

}