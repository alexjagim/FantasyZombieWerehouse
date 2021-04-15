using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Unit.Player.Humanoid
{
    public class PlayerLockOnEnemies : MonoBehaviour
    {
        [SerializeField, LabelText("Indicator Object")]
        private GameObject _obj_Indicator;

        private PlayerHumanoidController _playerController;
        private PlayerInputActions _inputActions;

        private int _iEnemyIndex = 0;
        private List<GameObject> _list_Enemies;

        // Start is called before the first frame update
        void Start()
        {
            _playerController = GetComponent<PlayerHumanoidController>();
            _inputActions = _playerController.GetInputActions();

            _list_Enemies = _playerController.GetGameManager().GetEnemiesList();
        }

        // Update is called once per frame
        void Update()
        {
            if (_inputActions.Player.LockOnEnemies.triggered)
            {
                IterateThroughEnemies();
            }

            if (_inputActions.Player.CancelLockOnEnemies.triggered && _playerController.IsLockedOntoEnemy)
            {
                _playerController.ToggleIsLockedOntoEnemy();

                DeactivateIndicator();
            }

            if (_playerController.IsLockedOntoEnemy)
            {
                Vector3 enemyPos = new Vector3(_list_Enemies[_iEnemyIndex].transform.position.x, 0.0f, _list_Enemies[_iEnemyIndex].transform.position.z);
                transform.LookAt(enemyPos);
            }
        }

        private void IterateThroughEnemies()
        {
            if (!_playerController.IsLockedOntoEnemy)
            {
                _iEnemyIndex = 0;
                _playerController.ToggleIsLockedOntoEnemy();

                ActivateIndicator(_list_Enemies[_iEnemyIndex].transform);
            }
            else
            {
                _iEnemyIndex++;

                if (_iEnemyIndex >= _list_Enemies.Count)
                {
                    _iEnemyIndex = 0;
                }

                SetIndicatorParent(_list_Enemies[_iEnemyIndex].transform);
            }
        }

        private void SetIndicatorParent(Transform trans)
        {
            if (_obj_Indicator != null)
            {
                _obj_Indicator.transform.parent = trans;
                _obj_Indicator.transform.localPosition = new Vector3(0, 0, 0);
            }
        }

        private void ActivateIndicator(Transform trans)
        {
            if (_obj_Indicator != null)
            {
                SetIndicatorParent(trans);
                _obj_Indicator.SetActive(true);
            }
        }

        private void DeactivateIndicator()
        {
            if (_obj_Indicator != null)
            {
                SetIndicatorParent(transform);
                _obj_Indicator.SetActive(false);
            }
        }

        private bool GetIndicatorIsActive()
        {
            if (_obj_Indicator != null)
            {
                return _obj_Indicator.activeSelf;
            }
            else
            {
                return false;
            }
        }
    }
}
