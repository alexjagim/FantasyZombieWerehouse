using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Unit.AI.ScriptableObject
{
    [CreateAssetMenu(menuName = "Pluggable/AI/Actions/Serach")]
    public class SearchAction : AIAction
    {
        public override void Act(StateController controller)
        {
            (controller as AIStateController).navMeshAgent.destination = (controller as AIStateController).LastKnownPositionOfTarget;
        }
    }
}