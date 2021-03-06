using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Foundation.Weapon.ScriptableObject;

namespace Foundation.Unit.Player.Humanoid.Weapon
{
    public class PlayerDuelWeaponHandler : PlayerWeaponHandler
    {
        private Dictionary<int, GameObject> _weapons_SecondaryEquipped;

        [Title("Secondary Weapon Variables")]
        [SerializeField, LabelText("Secondary Weapon Spawn Parent")]
        private Transform _trans_SecondaryWeaponSpawnParent;

        protected override void InstantiateVariables()
        {
            _weapons_SecondaryEquipped = new Dictionary<int, GameObject>();

            base.InstantiateVariables();
        }

        protected override void InstantiateWeapon(int index)
        {
            base.InstantiateWeapon(index);

            if (_weapons_Equipped[index] is DuelWieldWeapon)
            {
                GameObject temp = Instantiate((_weapons_Equipped[index] as DuelWieldWeapon).prefab_secondary);

                temp.transform.parent = _trans_SecondaryWeaponSpawnParent;
                temp.transform.localPosition = new Vector3(0, 0, 0);
                temp.transform.localRotation = Quaternion.identity;
                temp.transform.localScale = new Vector3(1, 1, 1);
                temp.SetActive(false);

                _weapons_SecondaryEquipped.Add(index, temp);
            }
        }

        protected override void SetupInitialWeapon()
        {
            base.SetupInitialWeapon();

            if (_weapons_SecondaryEquipped.ContainsKey(_iWeaponIndex))
            {
                _weapons_SecondaryEquipped[_iWeaponIndex].SetActive(true);
            }
        }
    }
}
