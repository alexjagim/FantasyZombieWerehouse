using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sirenix.OdinInspector;

public class StateController : MonoBehaviour
{
    public AIState currentState;
    public AIState remainState; 

    protected bool aiActive = true;

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
            Debug.Log("State End");
            currentState.DoExitStateActions(this);
            currentState = nextState;
        }
    }
}
