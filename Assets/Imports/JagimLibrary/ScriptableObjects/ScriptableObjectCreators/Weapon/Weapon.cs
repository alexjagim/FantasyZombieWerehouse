using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Generic Weapon")]
public class Weapon : ScriptableObject
{
    [BoxGroup("Base Properties")]
    public new string name;
    [BoxGroup("Base Properties")]
    public GameObject prefab;

    [BoxGroup("Base Properties")]
    public float attackSpeed;
    [BoxGroup("Base Properties")]
    public int damage;

    [LabelText("Animation Toggle"), BoxGroup("Base Properties")]
    public string sAnimationToggle;

    [LabelText("Head Horizontal Rotation"), Range(-1, 1), BoxGroup("Base Properties")]
    public float fHeadHorizontalRotation;

    [LabelText("Body Horizontal Rotation"), Range(-1, 1), BoxGroup("Base Properties")]
    public float fBodyHorizontalRotation;
}
