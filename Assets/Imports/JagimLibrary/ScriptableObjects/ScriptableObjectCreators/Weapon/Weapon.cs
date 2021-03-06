using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Generic Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public GameObject prefab;

    public float attackSpeed;
    public int damage;

    [LabelText("Animation Toggle")]
    public string sAnimationToggle;

    [LabelText("Head Horizontal Rotation"), Range(-1, 1)]
    public float fHeadHorizontalRotation;

    [LabelText("Body Horizontal Rotation"), Range(-1, 1)]
    public float fBodyHorizontalRotation;
}
