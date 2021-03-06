using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New Gun", menuName = "Weapons/Gun")]
public class Gun : Weapon
{
    public int ammoClipSize;

    public float projectileSpeed;

    [LabelText("Cone of Fire"), Range(0, 1)]
    public float fConeOfFire;
}
