using Foundation.Unit.Player.Humanoid;

namespace Foundation.Unit.Ability
{
    public class OnAttackAbility : Ability
    {
        public override sealed void Act(AbilityController controller)
        {
            if (controller.GetComponent<PlayerHumanoidController>().GetInputActions().Player.Attack.triggered)
            {
                AbilityFunctionality();
            }
        }

        protected virtual void AbilityFunctionality()
        {

        }
    }
}

