using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerWeaponHandler : UnitWeaponHandler
{
    protected PlayerInputActions _inputActions;

    [SerializeField, LabelText("Next Weapon Button Enabled")]
    protected bool _bNextWeaponToggleEnabled;

    protected override void InstantiateVariables()
    {
        base.InstantiateVariables();

        _inputActions = GetComponent<PlayerHumanoidController>().GetInputActions();       
    }

    protected override bool CanAttack()
    {
        return _inputActions.Player.Attack.triggered;
    }

    protected override void Attack()
    {
        base.Attack();

        Collider[] hitColliders = Physics.OverlapBox(_trans_WeaponDamagePosition.position, _vect_WeaponDamageSize / 2, Quaternion.identity);

        for (int i = 0; i < hitColliders.Length; ++i)
        {
            if (hitColliders[i].transform.tag == "Enemy")
            {
                hitColliders[i].GetComponent<UnitController>().TakeDamage(_weapon_Current.damage);
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
