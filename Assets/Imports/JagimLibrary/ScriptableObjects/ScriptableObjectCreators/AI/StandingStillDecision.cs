using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Pluggable/AI/Decisions/StandingStill")]
public class StandingStillDecision : AIDecision
{
    public override bool Decide(StateController controller)
    {
        return IsStandingStill(controller);
    }

    private bool IsStandingStill(StateController controller)
    {
        return Vector3.Distance(controller.transform.position, controller.GetComponent<NavMeshAgent>().pathEndPosition) <= 0.1f;
    }
}
