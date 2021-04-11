using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Pluggable/AI/Actions/SetCanAttack")]
public class SetCanAttackAction : AIAction
{
    [SerializeField, LabelText("Can Attack")]
    private bool _bCanAttack;

    public override void Act(StateController controller)
    {
        controller.GetComponent<AIWeaponHandler>().SetAttackState(_bCanAttack);
    }
}
