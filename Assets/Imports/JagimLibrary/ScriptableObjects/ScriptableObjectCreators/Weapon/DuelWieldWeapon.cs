using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New Duel Weapon", menuName = "Weapons/Generic Duel Weapon")]
public class DuelWieldWeapon : Weapon
{
    [LabelText("Secondary Weapon Prefab"), LabelWidth(155), BoxGroup("Duel Wield Properties")]
    public GameObject prefab_secondary;
    [LabelText("Secondary can be used for attack"), LabelWidth(195), BoxGroup("Duel Wield Properties")]
    public bool bSecondaryCanAttack;
    [LabelText("Secondary Weapon Damage"), LabelWidth(165), BoxGroup("Duel Wield Properties")]
    public int damage_secondary;
}
