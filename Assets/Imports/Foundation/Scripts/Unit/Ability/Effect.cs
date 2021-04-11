using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Unit.Ability
{
    public abstract class Effect : UnityEngine.ScriptableObject
    {
        [LabelText("Effect Type"), BoxGroup("Effect")]
        public AbilitySystemEnums.EffectType effectType;

        public abstract void Act(UnitController controller);
    }
}

