using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public AbilitySystemEnums.EffectType effectType;

    public abstract void Act(UnitController controller);
}
