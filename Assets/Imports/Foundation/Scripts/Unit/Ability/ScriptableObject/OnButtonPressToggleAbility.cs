using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;
using Foundation.Animation;

namespace Foundation.Unit.Ability.ScriptableObject
{
    [CreateAssetMenu(menuName = "Pluggable/AbilitySystem/Abilities/ButtonPressToggle")]
    public class OnButtonPressToggleAbility : OnButtonPressAbility
    {
        public AnimationAction[] animationTriggers_ToggleOff;
        public Effect[] effects_ToggleOff;

        public int iStaminaUsePerSecond;

        protected override sealed void AbilityFunctionality(AbilityController controller)
        {
            if (controller.GetAbilityIsToggledOn(this))
            {
                AbilityToggleOff(controller);
            }
            else
            {
                if (controller.GetUnitController().GetCurrentStamina() > iStaminaUsePerSecond)
                {
                    AbilityToggleOn(controller);
                }
            }
        }

        protected virtual void AbilityToggleOn(AbilityController controller)
        {
            controller.SetAbilityIsToggledOn(this, true);

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
            controller.StartStaminaReductionTimer(this, iStaminaUsePerSecond);
        }

        protected virtual void AbilityToggleOff(AbilityController controller)
        {
            controller.SetAbilityIsToggledOn(this, false);

            for (int i = 0; i < effectsToSelf.Length; ++i)
            {
                controller.RemoveEffect(effectsToSelf[i]);
            }

            for (int i = 0; i < effects_ToggleOff.Length; ++i)
            {
                controller.AddEffect(effects_ToggleOff[i]);
            }

            for (int i = 0; i < effectsToOthers.Length; ++i)
            {
                Debug.Log("Effects to Others not yet implemented");
            }

            for (int i = 0; i < animationTriggers.Length; ++i)
            {
                animationTriggers_ToggleOff[i].Act(controller.animator);
            }

            controller.StartCooldownTimer(this, cooldownTime);
        }

        public void ForceAbilityOff(AbilityController controller)
        {
            AbilityToggleOff(controller);
        }

        protected override bool CanTrigger(AbilityController controller)
        {
            return base.CanTrigger(controller);
        }
    }
}