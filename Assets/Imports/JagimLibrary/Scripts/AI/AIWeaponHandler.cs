using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class AIWeaponHandler : UnitWeaponHandler
{
    private bool _bCurrentlyAttacking;
    private bool _bAttackState;

    protected override void InstantiateVariables()
    {
        base.InstantiateVariables();

        _bCurrentlyAttacking = false;
    }

    protected override void Attack()
    {
        base.Attack();

        Collider[] hitColliders = Physics.OverlapBox(_trans_WeaponDamagePosition.position, _vect_WeaponDamageSize / 2, Quaternion.identity);

        for (int i = 0; i < hitColliders.Length; ++i)
        {
            if (hitColliders[i].transform.tag == "Player")
            {
                hitColliders[i].GetComponent<UnitController>().TakeDamage(_weapon_Current.damage);
            }
        }

        StartCoroutine(SetAttacking(1 / _weapon_Current.attackSpeed));
    }

    protected override bool CanAttack()
    {
        return !_bCurrentlyAttacking && _bAttackState;
    }

    private IEnumerator SetAttacking(float fDuration)
    {
        _bCurrentlyAttacking = true;

        yield return new WaitForSeconds(fDuration);

        _bCurrentlyAttacking = false;
    }

    public void SetAttackState(bool bAttacking)
    {
        _bAttackState = bAttacking;
    }
}
