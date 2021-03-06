using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerWeaponHandler : MonoBehaviour
{
    [Title("Weapon Variables")]
    [SerializeField, LabelText("Current Weapon")]
    protected Gun _weapon_Current;

    [SerializeField, LabelText("Equipped Weapons")]
    protected List<Gun> _weapons_Equipped;

    [SerializeField, LabelText("Weapon Spawn Parent")]
    private Transform _trans_WeaponSpawnParent;

    protected Animator _animator;
    protected PlayerInputActions _inputActions;

    protected GameObject _obj_weaponCurrent;

    protected List<GameObject> _list_weapons;

    protected int _iWeaponIndex;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        _inputActions = GetComponent<PlayerHumanoidController>().GetInputActions();

        _list_weapons = new List<GameObject>();

        foreach(Gun w in _weapons_Equipped)
        {
            InstantiateWeapon(w);
        }

        _iWeaponIndex = _weapons_Equipped.IndexOf(_weapon_Current);

        _obj_weaponCurrent = _list_weapons[_iWeaponIndex];
        _obj_weaponCurrent.SetActive(true);

        _animator.SetBool(_weapon_Current.sAnimationToggle, true);
        _animator.SetFloat("Head_Horizontal_f", _weapon_Current.fHeadHorizontalRotation);
        _animator.SetFloat("Body_Horizontal_f", _weapon_Current.fBodyHorizontalRotation);
    }

    protected virtual void InstantiateWeapon(Gun w)
    {
        GameObject temp = Instantiate(w.prefab);

        temp.transform.parent = _trans_WeaponSpawnParent;
        temp.transform.localPosition = new Vector3(0, 0, 0);
        temp.transform.localRotation = Quaternion.identity;
        temp.transform.localScale = new Vector3(1, 1, 1);
        temp.SetActive(false);

        _list_weapons.Add(temp);
    }

    protected virtual void SwitchWeapon(int iWeaponIndex)
    {
        if (iWeaponIndex == _iWeaponIndex)
        {
            return;
        }

        _iWeaponIndex = iWeaponIndex;

        _obj_weaponCurrent.SetActive(false);
        _animator.SetBool(_weapon_Current.sAnimationToggle, false);

        _obj_weaponCurrent = _list_weapons[iWeaponIndex];
        _weapon_Current = _weapons_Equipped[iWeaponIndex];

        _obj_weaponCurrent.SetActive(true);

        _animator.SetBool(_weapon_Current.sAnimationToggle, true);
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

    protected virtual void Update()
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

    }


}
