using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PluggableAI/Actions/Chase")]
public class ChaseAction : AIAction
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        (controller as AIStateController).navMeshAgent.destination = (controller as AIStateController).player.position;
    }
}
