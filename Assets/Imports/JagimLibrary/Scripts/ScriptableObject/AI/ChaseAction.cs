using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Pluggable/AI/Actions/Chase")]
public class ChaseAction : AIAction
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        (controller as AIStateController).navMeshAgent.destination = (controller as AIStateController).player.position;
        (controller as AIStateController).LastKnownPositionOfTarget = (controller as AIStateController).player.position;
    }
}
