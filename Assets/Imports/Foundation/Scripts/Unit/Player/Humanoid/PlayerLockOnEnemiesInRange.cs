using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Unit.Player.Humanoid
{
    public class PlayerLockOnEnemiesInRange : PlayerLockOnEnemies
    {
        [SerializeField, LabelText("Lock on Range")]
        private float _fRangeForLockOn;

        [SerializeField, LabelText("Automatically Update Locked on target"), LabelWidth(250.0f)]
        private bool _bAutomaticallyLockOnNextEnemy;

        [SerializeField, ReadOnly]
        private List<GameObject> _list_EnemiesInRange;

        protected override void InitVariables()
        {
            base.InitVariables();
        }

        protected override void UpdateObject()
        {
            UpdateEnemiesAlreadyInRange();

            UpdateIfEnemiesAreInRange();

            base.UpdateObject();
        }

        protected override void LockOnEnemiesFunctionality()
        {
            IterateThroughEnemies(_list_EnemiesInRange);
        }

        protected override void CancelLockOnEnemiesFunctionality()
        {
            base.CancelLockOnEnemiesFunctionality();
        }

        protected override void WhileLockedOnEnemyFunctionality()
        {
            LookTowardEnemyIndex(_list_EnemiesInRange);
        }

        private void UpdateEnemiesAlreadyInRange()
        {
            //Check if enemies are still in range
            for (int i = 0; i < _list_EnemiesInRange.Count; ++i)
            {
                //If enemies are no longer in range remove them from the list
                if (Vector3.Distance(transform.position, _list_EnemiesInRange[i].transform.position) > _fRangeForLockOn)
                {
                    GameObject temp = _list_EnemiesInRange[_iEnemyIndex];

                    _list_EnemiesInRange.Remove(_list_EnemiesInRange[i]);

                    //Update current index
                    //If the current locked on target has left range then cancel the lock on.
                    if (i == _iEnemyIndex)
                    {
                        if (_bAutomaticallyLockOnNextEnemy)
                        {
                            IterateThroughEnemies(_list_EnemiesInRange);
                        }
                        else
                        {
                            CancelLockOnEnemiesFunctionality();
                        }
                    }
                    //If a different enemy left range, upadate the index to the new index after enemy has been removed from the list.
                    else
                    {
                        _iEnemyIndex = _list_EnemiesInRange.IndexOf(temp);
                    }
                }
            }
        }

        private void UpdateIfEnemiesAreInRange()
        {
            for (int i = 0; i < _list_Enemies.Count; ++i)
            {
                //Check if new enemies are now in range
                if (Vector3.Distance(transform.position, _list_Enemies[i].transform.position) <= _fRangeForLockOn)
                {
                    //Make sure this enemy hasn't already been added to the list of enemies in range
                    if (!_list_EnemiesInRange.Contains(_list_Enemies[i]))
                    {
                        _list_EnemiesInRange.Add(_list_Enemies[i]);
                    }
                }
            }            
        }
    }
}

