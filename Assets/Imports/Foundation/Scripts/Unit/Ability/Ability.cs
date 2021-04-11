using Foundation.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Unit.Ability
{
    public abstract class Ability : UnityEngine.ScriptableObject
    {
        [LabelText("Icon"), BoxGroup("Ability")]
        public Sprite icon;
        [LabelText("Cooldown Time"), BoxGroup("Ability")]
        public float cooldownTime;

        [LabelText("Animation Triggers"), BoxGroup("Ability")]
        public AnimationAction[] animationTriggers;

        [LabelText("To Self"), BoxGroup("Ability/Effects")]
        public Effect[] effectsToSelf;
        [LabelText("To Others"), BoxGroup("Ability/Effects")]
        public Effect[] effectsToOthers;


        public abstract void Act(AbilityController controller);
    }
}

