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

        [SerializeField, LabelText("Vision Cone Size")]
        private float _fVisionCone = 45.0f;

        protected PlayerHumanoidController _playerController;
        private PlayerInputActions _inputActions;

        protected int _iEnemyIndex = 0;
        protected List<GameObject> _list_Enemies;

        protected List<GameObject> _list_Iteration;

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

            _list_Iteration = _list_Enemies;
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
            IterateThroughEnemies(_list_Iteration);
        }

        protected virtual void CancelLockOnEnemiesFunctionality()
        {
            _playerController.SetIsLockedOntoEnemy(false);

            DeactivateIndicator();
        }

        protected virtual void WhileLockedOnEnemyFunctionality()
        {
            LookTowardEnemyIndex(_list_Iteration);
        }

        protected void LookTowardEnemyIndex(List<GameObject> list)
        {
            Vector3 enemyPos = new Vector3(list[_iEnemyIndex].transform.position.x, 0.0f, list[_iEnemyIndex].transform.position.z);
            transform.LookAt(enemyPos);
        }

        protected void IterateThroughEnemies(List<GameObject> list)
        {
            if (list.Count <= 0)
            {
                CancelLockOnEnemiesFunctionality();

                return;
            }

            if (!_playerController.IsLockedOntoEnemy)
            {
                _iEnemyIndex = 0;
                _playerController.SetIsLockedOntoEnemy(true);

                ActivateIndicator(list[_iEnemyIndex].transform);
            }
            else
            {
                _iEnemyIndex++;

                if (_iEnemyIndex >= list.Count)
                {
                    _iEnemyIndex = 0;
                }

                SetIndicatorParent(list[_iEnemyIndex].transform);
            }
        }

        public void LockOntoClosestEnemyBeingLookedAt()
        {
            if (_list_Iteration.Count > 0)
            {
                GameObject obj_Closest = _list_Iteration[0];
                float fClosestDistance = Vector3.Distance(transform.position, _list_Iteration[0].transform.position);

                for (int i = 0; i < _list_Iteration.Count; ++i)
                {
                    if (ObjectIsWithinVisionCone(_list_Iteration[i]))
                    {
                        float dis = Vector3.Distance(transform.position, _list_Iteration[i].transform.position);

                        if (dis < fClosestDistance)
                        {
                            fClosestDistance = dis;
                            obj_Closest = _list_Iteration[i];
                        }
                    }
                }

                _iEnemyIndex = _list_Iteration.IndexOf(obj_Closest);

                if (_iEnemyIndex == 0)
                {
                    if (!ObjectIsWithinVisionCone(_list_Iteration[0]))
                    {
                        return;
                    }
                    else
                    {
                        _playerController.SetIsLockedOntoEnemy(true);

                        ActivateIndicator(_list_Iteration[_iEnemyIndex].transform);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private bool ObjectIsWithinVisionCone(GameObject obj)
        {
            Vector3 dir = obj.transform.position - transform.position;

            return Mathf.Abs(Mathf.Atan2(dir.y, dir.x * Mathf.Rad2Deg)) <= (_fVisionCone / 2);
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
