using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Foundation.Unit.AI.ScriptableObject
{
    [CreateAssetMenu(menuName = "Pluggable/AI/Actions/ClearNavDestination")]
    public class ClearNavDestinationAction : AIAction
    {
        public override void Act(StateController controller)
        {
            controller.GetComponent<NavMeshAgent>().SetDestination(controller.transform.position);
        }
    }
}