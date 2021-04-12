using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Unit.Ability.ScriptableObject
{
    [CreateAssetMenu(menuName = "Pluggable/AbilitySystem/Effects/ReduceDamage")]
    public class ReduceDamageEffect : Effect
    {
        [LabelText("Reduction Amount (%)"), LabelWidth(130), BoxGroup("Damage Reduction")]
        public float fReductionAmount;

        public override void Act(UnitController controller)
        {
            controller.SetDamageModifer(fReductionAmount);
        }
    }
}