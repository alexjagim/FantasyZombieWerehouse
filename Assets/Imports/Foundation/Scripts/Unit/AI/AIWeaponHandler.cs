using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Foundation.Weapon;

namespace Foundation.Unit.AI
{
    public class AIWeaponHandler : UnitWeaponHandler
    {
        private bool _bAttackState;

        protected override void InstantiateVariables()
        {
            base.InstantiateVariables();

            _bCurrentlyAttacking = false;
        }

        protected override void Attack()
        {
            base.Attack();

            if (_bHasAttackArea)
            {
                List<GameObject> _list_ObjectsInRange = _obj_weaponCurrent.GetComponent<WeaponAreaAttackManager>().GetComponent<WeaponAreaAttackManager>()._list_ObjectsInArea;

                for (int i = 0; i < _list_ObjectsInRange.Count; ++i)
                {
                    if (_list_ObjectsInRange[i].transform.tag == "Player")
                    {
                        _list_ObjectsInRange[i].GetComponent<UnitController>().TakeDamage(_weapon_Current.damage);
                    }
                }
            }
        }

        protected override bool CanAttack()
        {
            return !_bCurrentlyAttacking && _bAttackState;
        }

        public void SetAttackState(bool bAttacking)
        {
            _bAttackState = bAttacking;
        }
    }
}

