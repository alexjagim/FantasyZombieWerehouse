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
