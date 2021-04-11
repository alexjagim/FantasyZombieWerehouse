using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Unit.Ability.ScriptableObject
{
    [CreateAssetMenu(menuName = "Pluggable/AbilitySystem/Effects/ModifyMovementSpeed")]
    public class ModifyMovementSpeedEffect : Effect
    {
        [LabelText("Modification Amount"), BoxGroup("Movement Speed")]
        public float fModificationAmount;

        public override void Act(UnitController controller)
        {
            controller.ChangeMovementModifier(fModificationAmount);
        }
    }
}