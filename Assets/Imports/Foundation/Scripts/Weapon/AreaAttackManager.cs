using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Weapon
{
    public class AreaAttackManager : MonoBehaviour
    {
        [SerializeField]
        private WeaponAreaAttackManager _weaponManager;

        private void OnTriggerEnter(Collider other)
        {
            if (_weaponManager._list_Tags.Contains(other.tag))
            {
                _weaponManager._list_ObjectsInArea.Add(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_weaponManager._list_ObjectsInArea.Contains(other.gameObject))
            {
                _weaponManager._list_ObjectsInArea.Remove(other.gameObject);
            }
        }
    }
}
