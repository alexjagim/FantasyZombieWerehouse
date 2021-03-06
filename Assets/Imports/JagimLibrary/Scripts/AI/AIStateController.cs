using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sirenix.OdinInspector;

public class AIStateController : StateController
{
    public Transform player;

    [HideInInspector]
    public AIController enemyController;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    public Animator animator;

    public override void SetupAI()
    {
        base.SetupAI();

        enemyController = GetComponent<AIController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected override void OnExitState()
    {
        base.OnExitState();

        navMeshAgent.SetDestination(this.transform.position);
    }
}
