using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public Sprite icon;
    public float cooldownTime;
    public Effect[] effectsToSelf;
    public Effect[] effectsToOthers;
    public AnimationAction[] animationTriggers;

    public abstract void Act(AbilityController controller);
}
