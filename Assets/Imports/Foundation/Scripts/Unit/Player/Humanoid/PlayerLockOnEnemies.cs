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

        protected PlayerHumanoidController _playerController;
        private PlayerInputActions _inputActions;

        protected int _iEnemyIndex = 0;
        protected List<GameObject> _list_Enemies;

        // Start is called before the first frame update
        void Start()
        {
            InitVariables();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateObject();
        }

        protected virtual void InitVariables()
        {
            _playerController = GetComponent<PlayerHumanoidController>();
            _inputActions = _playerController.GetInputActions();

            _list_Enemies = _playerController.GetGameManager().GetEnemiesList();
        }

        protected virtual void UpdateObject()
        {
            if (GetLockOnEnemiesTriggered())
            {
                LockOnEnemiesFunctionality();
            }

            if (GetCancelLockOnEnemiesTriggered())
            {
                CancelLockOnEnemiesFunctionality();
            }

            if (_playerController.IsLockedOntoEnemy)
            {
                WhileLockedOnEnemyFunctionality();
            }
        }

        protected bool GetLockOnEnemiesTriggered()
        {
            return _inputActions.Player.LockOnEnemies.triggered;
        }

        protected bool GetCancelLockOnEnemiesTriggered()
        {
            return _inputActions.Player.CancelLockOnEnemies.triggered && _playerController.IsLockedOntoEnemy;
        }

        protected virtual void LockOnEnemiesFunctionality()
        {
            IterateThroughEnemies();
        }

        protected virtual void CancelLockOnEnemiesFunctionality()
        {
            _playerController.ToggleIsLockedOntoEnemy();

            DeactivateIndicator();
        }

        protected virtual void WhileLockedOnEnemyFunctionality()
        {
            Vector3 enemyPos = new Vector3(_list_Enemies[_iEnemyIndex].transform.position.x, 0.0f, _list_Enemies[_iEnemyIndex].transform.position.z);
            transform.LookAt(enemyPos);
        }

        protected void IterateThroughEnemies()
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

        protected void SetIndicatorParent(Transform trans)
        {
            if (_obj_Indicator != null)
            {
                _obj_Indicator.transform.parent = trans;
                _obj_Indicator.transform.localPosition = new Vector3(0, 0, 0);
            }
        }

        protected void ActivateIndicator(Transform trans)
        {
            if (_obj_Indicator != null)
            {
                SetIndicatorParent(trans);
                _obj_Indicator.SetActive(true);
            }
        }

        protected void DeactivateIndicator()
        {
            if (_obj_Indicator != null)
            {
                SetIndicatorParent(transform);
                _obj_Indicator.SetActive(false);
            }
        }

        protected bool GetIndicatorIsActive()
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
