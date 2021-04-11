using Foundation.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Weapon.Gun
{
    public class TakingBulletDamage : MonoBehaviour
    {
        private UnitController _controller;

        private void Awake()
        {
            _controller = GetComponent<UnitController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "Bullet")
            {
                _controller.TakeDamage(other.transform.parent.gameObject.GetComponent<ProjectileInformation>().Damage);
            }
        }
    }
}