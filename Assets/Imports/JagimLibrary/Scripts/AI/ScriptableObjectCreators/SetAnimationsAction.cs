using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "PluggableAI/Actions/SetAnimations")]
public class SetAnimationsAction : AIAction
{
    public List<AnimationParameterInfo> _list_Animations;

    public override void Act(StateController controller)
    {
        foreach(AnimationParameterInfo animation in _list_Animations)
        {
            switch(animation.parameter)
            {
                case AnimatorControllerParameterType.Bool:
                    {
                        controller.animator.SetBool(animation.sID, animation.bValue);
                        break;
                    }
                case AnimatorControllerParameterType.Float:
                    {
                        controller.animator.SetFloat(animation.sID, animation.fValue);
                        break;
                    }
                case AnimatorControllerParameterType.Int:
                    {
                        controller.animator.SetInteger(animation.sID, animation.iValue);
                        break;
                    }
                case AnimatorControllerParameterType.Trigger:
                    {
                        controller.animator.SetTrigger(animation.sID);
                        break;
                    }
            }
        }
    }
}
