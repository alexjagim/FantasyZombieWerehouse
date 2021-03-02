using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : BaseState
{
    private NavMeshAgent agent;
    private CapsuleCollider col;
    private Transform target;
    private EnemyController controller;

    public ChaseState(EnemyController obj) : base(obj.gameObject)
    {
        controller = obj;
        agent = obj.gameObject.GetComponent<NavMeshAgent>();
        target = obj.Target;
    }

    public override Type Tick()
    {
        RaycastHit hit;

        if (agent.pathEndPosition != target.position)
        {
            agent.SetDestination(target.position);
        }

        if (Physics.SphereCast(controller.transform.position, 1.5f, controller.transform.forward, out hit, 0.1f))
        {
            if (hit.transform.tag == "Player")
            {
                agent.SetDestination(controller.transform.position);
                return typeof(IdleState);
            }
        }

        return null;
    }
}
