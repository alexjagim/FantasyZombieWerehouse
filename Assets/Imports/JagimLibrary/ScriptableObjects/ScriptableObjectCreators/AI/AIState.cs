using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/AI/State")]
public class AIState : ScriptableObject
{
    public AIAction[] actions;
    public AnimationAction[] animationActions;
    public AITransition[] transitions;
    public AIAction[] exitStateActions;
    
    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; ++i)
        {
            actions[i].Act(controller);
        }
    }

    public void DoAnimationActions(StateController controller)
    {
        for (int i = 0; i < animationActions.Length; ++i)
        {
            animationActions[i].Act(controller.animator);
        }
    }

    public void DoExitStateActions(StateController controller)
    {
        for (int i = 0; i < exitStateActions.Length; ++i)
        {
            exitStateActions[i].Act(controller);
        }
    }

    private void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; ++i)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded)
            {
                controller.TransitionToState(transitions[i].trueState);
            }
            else
            {
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }
}
