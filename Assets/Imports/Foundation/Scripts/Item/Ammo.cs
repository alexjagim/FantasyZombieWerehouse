﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Foundation.Weapon.ScriptableObject;
using Foundation.Unit.Player.Humanoid.Weapon;

namespace Foundation.Item
{
    public class Ammo : PickupItem
    {
        [SerializeField, LabelText("Ammo Picked Up (Clips)")]
        private int iPickUpAmount;

        [SerializeField, LabelText("Assigned Weapon")]
        private Gun weapon;

        public override void Pickup(GameObject obj)
        {
            obj.GetComponent<PlayerGunHandler>().AddAmmo(iPickUpAmount, weapon);
        }
    }
}