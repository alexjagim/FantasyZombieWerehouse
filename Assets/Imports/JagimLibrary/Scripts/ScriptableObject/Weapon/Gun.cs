using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New Gun", menuName = "Weapons/Gun")]
public class Gun : Weapon
{
    [BoxGroup("Gun Properties")]
    public int ammoClipSize;

    [BoxGroup("Gun Properties")]
    public float projectileSpeed;

    [LabelText("Cone of Fire"), Range(0, 1), BoxGroup("Gun Properties")]
    public float fConeOfFire;
}
