using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sirenix.OdinInspector;

namespace Foundation.Unit.AI
{
    public class AIStateController : StateController
    {
        public Transform player;

        private Vector3 _vect_LastKnownPositionOfTarget;

        public Vector3 LastKnownPositionOfTarget
        {
            get
            {
                return _vect_LastKnownPositionOfTarget;
            }
            set
            {
                _vect_LastKnownPositionOfTarget = value;
            }
        }

        [HideInInspector]
        public NavMeshAgent navMeshAgent;

        public void SetAIActive(bool bActive)
        {
            aiActive = bActive;
        }

        public override void SetupAI()
        {
            base.SetupAI();

            navMeshAgent = GetComponent<NavMeshAgent>();
        }
    }
}

