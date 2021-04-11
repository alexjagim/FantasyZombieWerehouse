using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Pluggable/AI/Decisions/WithinDistance")]
public class WithinDistanceDecision : AIDecision
{
    [LabelText("Distance")]
    public float fDistance;

    public override bool Decide(StateController controller)
    {
        return WithinDistance(controller);
    }

    public bool WithinDistance(StateController controller)
    {
        if (Vector3.Distance((controller as AIStateController).player.transform.position, controller.transform.position) <= fDistance)
        {
            return true;
        }

        return false;
    }
}
