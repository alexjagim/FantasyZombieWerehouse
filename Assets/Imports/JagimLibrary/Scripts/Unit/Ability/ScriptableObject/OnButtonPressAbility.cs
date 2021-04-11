using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

namespace Foundation.Unit.Ability.ScriptableObject
{
    [CreateAssetMenu(menuName = "Pluggable/AbilitySystem/Abilities/ButtonPressGeneric")]
    public class OnButtonPressAbility : Ability
    {
        [HideInInspector]
        public InputAction input;

        public override sealed void Act(AbilityController controller)
        {
            if (input.triggered)
            {
                if (CanTrigger(controller))
                {
                    AbilityFunctionality(controller);
                }
            }
        }

        protected virtual bool CanTrigger(AbilityController controller)
        {
            return controller.GetAbilityCanTrigger(this);
        }

        protected virtual void AbilityFunctionality(AbilityController controller)
        {
            for (int i = 0; i < effectsToSelf.Length; ++i)
            {
                controller.AddEffect(effectsToSelf[i]);
            }

            for (int i = 0; i < effectsToOthers.Length; ++i)
            {
                Debug.Log("Effects to Others not yet implemented");
            }

            for (int i = 0; i < animationTriggers.Length; ++i)
            {
                animationTriggers[i].Act(controller.animator);
            }

            controller.StartCooldownTimer(this, cooldownTime);
        }
    }
}