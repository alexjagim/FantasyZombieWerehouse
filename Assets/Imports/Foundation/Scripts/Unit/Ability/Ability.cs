using Foundation.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Unit.Ability
{
    public abstract class Ability : UnityEngine.ScriptableObject
    {
        public Sprite icon;
        public float cooldownTime;
        public Effect[] effectsToSelf;
        public Effect[] effectsToOthers;
        public AnimationAction[] animationTriggers;

        public abstract void Act(AbilityController controller);
    }
}

