using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Animations/SetAnimations")]
public class SetAnimationsAction : AnimationAction
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
                        (controller as AIStateController).animator.SetBool(animation.sID, animation.bValue);
                        break;
                    }
                case AnimatorControllerParameterType.Float:
                    {
                        (controller as AIStateController).animator.SetFloat(animation.sID, animation.fValue);
                        break;
                    }
                case AnimatorControllerParameterType.Int:
                    {
                        (controller as AIStateController).animator.SetInteger(animation.sID, animation.iValue);
                        break;
                    }
                case AnimatorControllerParameterType.Trigger:
                    {
                        (controller as AIStateController).animator.SetTrigger(animation.sID);
                        break;
                    }
            }
        }
    }
}
