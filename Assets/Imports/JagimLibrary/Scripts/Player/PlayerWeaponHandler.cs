using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerWeaponHandler : MonoBehaviour
{
    [Title("Weapon Variables")]
    [SerializeField, LabelText("Current Weapon")]
    protected Weapon _weapon_Current;

    [SerializeField, LabelText("Equipped Weapons")]
    protected List<Weapon> _weapons_Equipped;

    [SerializeField, LabelText("Weapon Spawn Parent")]
    private Transform _trans_WeaponSpawnParent;

    [SerializeField, LabelText("Damage Position")]
    private Transform _trans_WeaponDamagePosition;

    [SerializeField, LabelText("Damage Area Size")]
    private Vector3 _vect_WeaponDamageSize;

    [SerializeField, LabelText("Debug Damage Area")]
    private bool _bDebugDamageArea;

    protected Animator _animator;
    protected PlayerInputActions _inputActions;

    protected GameObject _obj_weaponCurrent;

    protected List<GameObject> _list_weapons;

    protected int _iWeaponIndex;

    protected virtual void InstantiateVariables()
    {
        _animator = GetComponent<PlayerHumanoidController>().GetAnimator();
        _inputActions = GetComponent<PlayerHumanoidController>().GetInputActions();

        _list_weapons = new List<GameObject>();

        for (int i = 0; i < _weapons_Equipped.Count; ++i)
        {
            InstantiateWeapon(i);
        }

        _iWeaponIndex = _weapons_Equipped.IndexOf(_weapon_Current);

        SetupInitialWeapon();

        AnimationEquipWeapon();
        _animator.SetFloat("Head_Horizontal_f", _weapon_Current.fHeadHorizontalRotation);
        _animator.SetFloat("Body_Horizontal_f", _weapon_Current.fBodyHorizontalRotation);
    }

    protected virtual void AnimationEquipWeapon()
    {
        _animator.SetBool(_weapon_Current.sAnimationToggle, true);
    }

    protected virtual void AnimationUnequipWeapon()
    {
        _animator.SetBool(_weapon_Current.sAnimationToggle, false);
    }

    protected virtual void InstantiateWeapon(int index)
    {
        GameObject temp = Instantiate(_weapons_Equipped[index].prefab);

        temp.transform.parent = _trans_WeaponSpawnParent;
        temp.transform.localPosition = new Vector3(0, 0, 0);
        temp.transform.localRotation = Quaternion.identity;
        temp.transform.localScale = new Vector3(1, 1, 1);
        temp.SetActive(false);

        _list_weapons.Add(temp);
    }

    protected virtual void SetupInitialWeapon()
    {
        _obj_weaponCurrent = _list_weapons[_iWeaponIndex];
        _obj_weaponCurrent.SetActive(true);
    }

    protected virtual void SwitchWeapon(int iWeaponIndex)
    {
        if (iWeaponIndex == _iWeaponIndex)
        {
            return;
        }

        _iWeaponIndex = iWeaponIndex;

        _obj_weaponCurrent.SetActive(false);
        AnimationUnequipWeapon();

        _obj_weaponCurrent = _list_weapons[iWeaponIndex];
        _weapon_Current = _weapons_Equipped[iWeaponIndex];

        _obj_weaponCurrent.SetActive(true);

        AnimationEquipWeapon();
        _animator.SetFloat("Head_Horizontal_f", _weapon_Current.fHeadHorizontalRotation);
        _animator.SetFloat("Body_Horizontal_f", _weapon_Current.fBodyHorizontalRotation);
    }

    public void NextWeapon()
    {
        int i = _iWeaponIndex + 1;

        if (i >= _weapons_Equipped.Count)
        {
            i = 0;
        }

        SwitchWeapon(i);
    }

    protected virtual void UpdateObject()
    {
        if(CanAttack())
        {
            Attack();
        }
    }

    protected virtual bool CanAttack()
    {
        return false;
    }

    protected virtual void Attack()
    {
        Collider[] hitColliders = Physics.OverlapBox(_trans_WeaponDamagePosition.position, _vect_WeaponDamageSize / 2, Quaternion.identity);

        for (int i = 0; i < hitColliders.Length; ++i)
        {
            if (hitColliders[i].transform.tag == "Enemy")
            {
                hitColliders[i].GetComponent<UnitController>().TakeDamage(_weapon_Current.damage);
            }
        }
    }

    private void Start()
    {
        InstantiateVariables();
    }

    private void Update()
    {
        UpdateObject();
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (_bDebugDamageArea)
            Gizmos.DrawWireCube(_trans_WeaponDamagePosition.position, _vect_WeaponDamageSize);
    }
}
