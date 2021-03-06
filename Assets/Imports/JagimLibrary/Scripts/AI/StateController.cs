using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sirenix.OdinInspector;

public class StateController : MonoBehaviour
{
    public AIState currentState;
    public AIState remainState;

    [LabelText("Sight Range")]
    public float fSightRange;
    [LabelText("Attack Range")]
    public float fAttackRange;

    public Transform player;

    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    [HideInInspector]
    public AIController enemyController;

    public Animator animator;

    private bool aiActive = true;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyController = GetComponent<AIController>();
    }

    public void SetupAI()
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

    private void OnExitState()
    {
        navMeshAgent.SetDestination(this.transform.position);
    }
}
