using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Weapon.ScriptableObject
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Generic Weapon")]
    public class GenericWeapon : UnityEngine.ScriptableObject
    {
        [BoxGroup("Base Properties")]
        public new string name;
        [BoxGroup("Base Properties")]
        public GameObject prefab;

        [LabelText("Attack Speed (per sec)"), LabelWidth(135), BoxGroup("Base Properties")]
        public float attackSpeed;
        [BoxGroup("Base Properties")]
        public int damage;

        [LabelText("Animation Toggle"), BoxGroup("Base Properties")]
        public string sAnimationToggle;

        [LabelText("Animation Delay"), BoxGroup("Base Properties")]
        public float fAnimationDelay;

        [BoxGroup("Base Properties"), LabelWidth(145)]
        public bool canRotateDuringAttack;
        [BoxGroup("Base Properties"), LabelWidth(145)]
        public bool canMoveDuringAttack;

        [BoxGroup("Base Properties"), LabelWidth(165)]
        public bool usesAreaOfEffectDamage;

        [BoxGroup("Base Properties")]
        public bool knockbackEffect;

        [BoxGroup("Base Properties"), ShowIf("knockbackEffect")]
        public float knockbackForce;

        [BoxGroup("Base Properties"), ShowIf("knockbackEffect")]
        public float knockbackDistance;


        [LabelText("Head Horizontal Rotation"), Range(-1, 1), BoxGroup("Base Properties")]
        public float fHeadHorizontalRotation;

        [LabelText("Body Horizontal Rotation"), Range(-1, 1), BoxGroup("Base Properties")]
        public float fBodyHorizontalRotation;
    }
}
