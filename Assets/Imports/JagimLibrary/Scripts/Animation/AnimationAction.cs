using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Animation
{
    public abstract class AnimationAction : UnityEngine.ScriptableObject
    {
        public abstract void Act(Animator animator);
    }
}

