using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Foundation.Weapon.ScriptableObject;

namespace Foundation.Unit
{
    public class UnitWeaponHandler : MonoBehaviour
    {
        [Title("Weapon Variables")]
        [SerializeField, LabelText("Current Weapon")]
        protected GenericWeapon _weapon_Current;

        [SerializeField, LabelText("Equipped Weapons")]
        protected List<GenericWeapon> _weapons_Equipped;

        [SerializeField, LabelText("Weapon Spawn Parent")]
        protected Transform _trans_WeaponSpawnParent;

        [SerializeField, LabelText("Damage Position")]
        protected Transform _trans_WeaponDamagePosition;

        [SerializeField, LabelText("Damage Area Size")]
        protected Vector3 _vect_WeaponDamageSize;

        [SerializeField, LabelText("Debug Damage Area")]
        private bool _bDebugDamageArea;

        protected Animator _animator;

        protected GameObject _obj_weaponCurrent;

        protected List<GameObject> _list_weapons;

        protected int _iWeaponIndex;

        protected bool _bCurrentlyAttacking;

        protected HumanoidController _humanoidController;

        protected virtual void InstantiateVariables()
        {
            _humanoidController = GetComponent<HumanoidController>();

            _animator = _humanoidController.GetAnimator();

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

        protected virtual void InstantiateWeapon(int index)
        {
            GameObject temp;

            if (_weapons_Equipped[index].prefab != null)
            {
                temp = Instantiate(_weapons_Equipped[index].prefab);
                temp.transform.localScale = _weapons_Equipped[index].prefab.transform.localScale;
            }
            else
            {
                temp = new GameObject();
                temp.transform.localScale = new Vector3(1, 1, 1);
            }

            temp.transform.parent = _trans_WeaponSpawnParent;
            temp.transform.localPosition = new Vector3(0, 0, 0);
            temp.transform.localRotation = Quaternion.identity;
            temp.SetActive(false);

            _list_weapons.Add(temp);
        }

        protected virtual void SetupInitialWeapon()
        {
            _obj_weaponCurrent = _list_weapons[_iWeaponIndex];
            _obj_weaponCurrent.SetActive(true);
        }

        protected virtual void AnimationEquipWeapon()
        {

        }

        protected virtual void AnimationUnequipWeapon()
        {

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
            TriggerAttack();
        }

        protected virtual bool CanAttack()
        {
            return !_bCurrentlyAttacking;
        }

        protected virtual void Attack()
        {
            StartCoroutine(SetAttacking(1 / _weapon_Current.attackSpeed));

            _animator.SetTrigger(_weapon_Current.sAnimationToggle);
        }

        public void TriggerAttack()
        {
            if (CanAttack())
            {
                Attack();
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

        protected IEnumerator SetAttacking(float fDuration)
        {
            _bCurrentlyAttacking = true;

            bool bMoveTemp = _humanoidController.CanMove;
            bool bRotateTemp = _humanoidController.CanRotate;

            if (bMoveTemp)
            {
                _humanoidController.CanMove = _weapon_Current.canMoveDuringAttack;
            }

            if (bRotateTemp)
            {
                _humanoidController.CanRotate = _weapon_Current.canMoveDuringAttack;
            }

            yield return new WaitForSeconds(fDuration);

            _humanoidController.CanMove = bMoveTemp;
            _humanoidController.CanRotate = bRotateTemp;

            _bCurrentlyAttacking = false;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            if (_bDebugDamageArea)
                Gizmos.DrawWireCube(_trans_WeaponDamagePosition.position, _vect_WeaponDamageSize);
        }
    }
}