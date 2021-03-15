using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Serach")]
public class SearchAction : AIAction
{
    public override void Act(StateController controller)
    {
        (controller as AIStateController).navMeshAgent.destination = (controller as AIStateController).LastKnownPositionOfTarget;
    }
}
