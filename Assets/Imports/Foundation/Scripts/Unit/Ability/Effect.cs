using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Unit.Ability
{
    public abstract class Effect : UnityEngine.ScriptableObject
    {
        public AbilitySystemEnums.EffectType effectType;

        public abstract void Act(UnitController controller);
    }
}

