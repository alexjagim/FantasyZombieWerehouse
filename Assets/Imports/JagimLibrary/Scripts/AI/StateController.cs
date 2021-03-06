using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sirenix.OdinInspector;

public class StateController : MonoBehaviour
{
    public AIState currentState;
    public AIState remainState;

    private bool aiActive = true;

    private void Awake()
    {
        SetupAI();
    }

    public virtual void SetupAI()
    {
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
            currentState = nextState;
            OnExitState();
        }
    }

    protected virtual void OnExitState()
    {

    }
}
