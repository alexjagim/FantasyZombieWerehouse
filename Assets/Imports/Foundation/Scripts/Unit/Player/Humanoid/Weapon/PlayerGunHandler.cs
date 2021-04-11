using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Foundation.Weapon.ScriptableObject;
using Foundation.Weapon.Gun;

namespace Foundation.Unit.Player.Humanoid.Weapon
{
    public class PlayerGunHandler : PlayerWeaponHandler
    {
        [Title("Gun Variables")]
        [SerializeField, LabelText("Bullet Prefab")]
        private GameObject _bulletPrefab;

        [SerializeField, LabelText("Number of Ammo Clips")]
        private int _iNumberOfClips
        {
            get
            {
                return _obj_weaponCurrent.GetComponent<GunController>().iNumberOfClipsRemaining;
            }
            set
            {
                _obj_weaponCurrent.GetComponent<GunController>().iNumberOfClipsRemaining = value;
            }
        }

        [SerializeField, LabelText("Ammo Clip Size"), ReadOnly]
        private int _iAmmoClipSize;

        [SerializeField, LabelText("Current Ammo"), ReadOnly]
        private int _iAmmoCurrent
        {
            get
            {
                return _obj_weaponCurrent.GetComponent<GunController>().iNumberOfShotsRemaining;
            }
            set
            {
                _obj_weaponCurrent.GetComponent<GunController>().iNumberOfShotsRemaining = value;
            }
        }

        private bool _bIsReloading = false;
        private bool _bIsFiring = false;

        private Transform _trans_bulletSpawnPosition;

        protected override void InstantiateVariables()
        {
            base.InstantiateVariables();

            _iAmmoClipSize = (_weapon_Current as Gun).ammoClipSize;
            _iAmmoCurrent = _iAmmoClipSize;

            _trans_bulletSpawnPosition = _obj_weaponCurrent.GetComponent<GunController>().trans_BulletSpawn;
        }

        protected override void UpdateObject()
        {
            if (CanAttack())
            {
                if (_iAmmoCurrent > 0)
                {
                    Attack();
                }
                else
                {
                    if (_iNumberOfClips > 0)
                    {
                        Reload();
                    }
                }
            }

            if (_inputActions.Player.Reload.triggered && _iNumberOfClips > 0)
            {
                Reload();
            }
        }

        protected override void Attack()
        {
            Fire();
        }

        private void Fire()
        {
            GameObject obj = Instantiate(_bulletPrefab, _trans_bulletSpawnPosition.position, GetBulletRotation(), null);
            obj.GetComponent<ProjectileInformation>().Speed = (_weapon_Current as Gun).projectileSpeed;
            obj.GetComponent<ProjectileInformation>().Damage = _weapon_Current.damage;

            _animator.SetTrigger("Fire");

            _obj_weaponCurrent.GetComponent<GunController>().PlayGunFireAnimation();

            _iAmmoCurrent--;
        }

        protected virtual Quaternion GetBulletRotation()
        {
            if ((_weapon_Current as Gun).fConeOfFire == 0)
            {
                return transform.rotation;
            }
            else
            {
                float fDegrees = Random.Range(0, (_weapon_Current as Gun).fConeOfFire) - ((_weapon_Current as Gun).fConeOfFire / 2);

                return new Quaternion(transform.rotation.x, transform.rotation.y + fDegrees, transform.rotation.z, transform.rotation.w);
            }
        }

        protected override bool CanAttack()
        {
            return _inputActions.Player.Attack.triggered && !_bIsReloading && !_bIsFiring;
        }

        public void TriggerFire()
        {
            _bIsFiring = true;
        }

        public void TriggerIsDoneFiring()
        {
            _bIsFiring = false;
        }

        private void Reload()
        {
            _iNumberOfClips--;
            _animator.SetTrigger("Reload");
        }

        public void TriggerReloading()
        {
            _bIsReloading = true;
        }

        public void TriggerIsDoneReloading()
        {
            _iAmmoCurrent = _iAmmoClipSize;

            _bIsReloading = false;
        }

        public void AddAmmo(int iAmount, Gun weapon)
        {
            if (weapon != null)
            {
                _list_weapons[_weapons_Equipped.IndexOf(weapon)].GetComponent<GunController>().iNumberOfClipsRemaining += iAmount;
            }
        }
    }
}