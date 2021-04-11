using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sirenix.OdinInspector;

namespace Foundation.Unit.AI
{
    public class StateController : MonoBehaviour
    {
        public AIState currentState;
        public AIState remainState;

        public Animator animator;

        protected bool aiActive = true;

        private void Awake()
        {
            SetupAI();
        }

        public virtual void SetupAI()
        {
        }

        private void Start()
        {
            currentState.DoAnimationActions(this);
        }

        public void Update()
        {
            if (!aiActive)
                return;
            currentState.UpdateState(this);
        }

        public void TransitionToState(AIState nextState)
        {
            if (nextState != remainState)
            {
                Debug.Log("State End");
                currentState.DoExitStateActions(this);
                currentState = nextState;
                currentState.DoAnimationActions(this);
            }
        }
    }
}
