using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public GameObject prefab;

    public float fireSpeed;
    public int ammoClipSize;

    public float projectileSpeed;
    public int damage;

    [LabelText("Cone of Fire"), Range(0, 1)]
    public float fConeOfFire;

    [LabelText("Animation Toggle")]
    public string sAnimationToggle;

    [LabelText("Head Horizontal Rotation"), Range(-1, 1)]
    public float fHeadHorizontalRotation;

    [LabelText("Body Horizontal Rotation"), Range(-1, 1)]
    public float fBodyHorizontalRotation;
}
