using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Pluggable/Animations/SetAnimations")]
public class SetAnimationsAction : AnimationAction
{
    public List<AnimationParameterInfo> _list_Animations;

    public override void Act(Animator animator)
    {
        foreach(AnimationParameterInfo animation in _list_Animations)
        {
            switch(animation.parameter)
            {
                case AnimatorControllerParameterType.Bool:
                    {
                        animator.SetBool(animation.sID, animation.bValue);
                        break;
                    }
                case AnimatorControllerParameterType.Float:
                    {
                        animator.SetFloat(animation.sID, animation.fValue);
                        break;
                    }
                case AnimatorControllerParameterType.Int:
                    {
                        animator.SetInteger(animation.sID, animation.iValue);
                        break;
                    }
                case AnimatorControllerParameterType.Trigger:
                    {
                        animator.SetTrigger(animation.sID);
                        break;
                    }
            }
        }
    }
}
