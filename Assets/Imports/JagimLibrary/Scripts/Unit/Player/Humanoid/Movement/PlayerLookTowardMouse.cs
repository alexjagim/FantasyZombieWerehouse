using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Unit.Player.Humanoid.Movement
{
    [RequireComponent(typeof(PlayerHumanoidController))]
    public class PlayerLookTowardMouse : MonoBehaviour
    {
        private PlayerInputActions _inputActions;

        [SerializeField, LabelText("Lock-On Enabled")]
        private bool _bLockOnEnabled;

        private GameManager _gameManager;

        [SerializeField, LabelText("Lock On Distance"), ShowIf("_bLockOnEnabled"), Indent]
        private float _fLockOnDistance = 0;

        private GameObject _nearbyTarget;
        private List<GameObject> _lockOnTargets;

        private void Start()
        {
            _inputActions = GetComponent<PlayerHumanoidController>().GetInputActions();

            if (_bLockOnEnabled)
            {
                _lockOnTargets = new List<GameObject>();

                _gameManager = GetComponent<PlayerHumanoidController>().GetGameManager();

                _lockOnTargets = _gameManager.GetEnemiesList();
            }
        }

        // Update is called once per frame
        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(_inputActions.Player.Mouse.ReadValue<Vector2>()); ;
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 target = hit.point;
                target.y = transform.position.y;

                if (CheckIfNearbyTarget(target))
                {
                    transform.LookAt(_nearbyTarget.transform);
                }
                else
                {
                    transform.LookAt(target);
                }
            }
        }

        private bool CheckIfNearbyTarget(Vector3 target)
        {
            if (!_bLockOnEnabled)
            {
                return false;
            }

            _lockOnTargets = _gameManager.GetEnemiesList();

            foreach (GameObject obj in _lockOnTargets)
            {
                if (obj == null)
                {
                    return false;
                }

                if (Vector3.Distance(target, obj.transform.position) <= _fLockOnDistance)
                {
                    _nearbyTarget = obj;

                    return true;
                }
            }

            return false;
        }
    }
}