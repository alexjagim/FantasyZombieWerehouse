using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/AbilitySystem/Effects/ReduceDamage")]
public class ReduceDamageEffect : Effect
{
    public float fReductionAmount;

    public override void Act(UnitController controller)
    {
        controller.SetDamageModifer(fReductionAmount);
    }
}
