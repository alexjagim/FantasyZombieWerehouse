using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/AbilitySystem/Effects/ModifyMovementSpeed")]
public class ModifyMovementSpeedEffect : Effect
{
    public float fModificationAmount;

    public override void Act(UnitController controller)
    {
        controller.ChangeMovementModifier(fModificationAmount);
    }
}
