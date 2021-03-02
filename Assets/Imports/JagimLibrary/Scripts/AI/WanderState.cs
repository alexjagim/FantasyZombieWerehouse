using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : BaseState
{
    private NavMeshAgent agent;
    private CapsuleCollider col;
    private Transform target;
    private EnemyController controller;

    public WanderState(EnemyController obj) : base(obj.gameObject)
    {
        controller = obj;
        agent = obj.gameObject.GetComponent<NavMeshAgent>();
        target = obj.Target;
    }

    public override Type Tick()
    {
        RaycastHit hit;

        if (Physics.SphereCast(controller.transform.position, 10f, controller.transform.forward, out hit, 0.1f))
        {
            if (hit.transform.tag == "Player")
            {
                controller.Target = hit.transform;
                return typeof(ChaseState);
            }
        }

        return null;
    }
}
