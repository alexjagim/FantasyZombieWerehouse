using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Foundation.Unit.AI.Humanoid;
using Foundation.Weapon;

namespace Foundation.Unit.Player.Humanoid.Weapon
{
    public class PlayerWeaponHandler : UnitWeaponHandler
    {
        protected PlayerInputActions _inputActions;

        [SerializeField, LabelText("Next Weapon Button Enabled")]
        protected bool _bNextWeaponToggleEnabled;

        private bool _bContainsLockOnEnemiesScript = false;

        protected override void InstantiateVariables()
        {
            base.InstantiateVariables();

            _inputActions = GetComponent<PlayerHumanoidController>().GetInputActions();

            _bContainsLockOnEnemiesScript = TryGetComponent(out PlayerLockOnEnemies script);
        }

        protected override bool CanAttack()
        {
            return _inputActions.Player.Attack.triggered && base.CanAttack();
        }

        protected override void Attack()
        {
            base.Attack();

            if(_bContainsLockOnEnemiesScript)
            {
                if (!_humanoidController.IsLockedOntoEnemy)
                {
                    GetComponent<PlayerLockOnEnemies>().LockOntoClosestEnemyBeingLookedAt();
                }
            }

            if (_bHasAttackArea)
            {
                List<GameObject> _list_ObjectsInRange = _obj_weaponCurrent.GetComponent<WeaponAreaAttackManager>()._list_ObjectsInArea;

                for (int i = 0; i < _list_ObjectsInRange.Count; ++i)
                {
                    if (_list_ObjectsInRange[i].transform.tag == "Enemy")
                    {
                        Debug.Log("Hit Enemy");

                        _list_ObjectsInRange[i].GetComponent<UnitController>().TakeDamage(_weapon_Current.damage);

                        if (_weapon_Current.knockbackEffect)
                        {
                            _list_ObjectsInRange[i].GetComponent<AIHumanoidController>().BeKnockedBack(this.transform, _weapon_Current.knockbackDistance, _weapon_Current.knockbackForce);
                        }
                    }
                }
            }
        }

        protected override void UpdateObject()
        {
            base.UpdateObject();

            if (_inputActions.Player.NextWeapon.triggered && _bNextWeaponToggleEnabled)
            {
                NextWeapon();
            }
        }
    }
}
