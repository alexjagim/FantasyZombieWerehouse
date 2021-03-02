using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    private UnityEngine.AI.NavMeshAgent agent;
    private CapsuleCollider col;
    private Transform target;
    private EnemyController controller;

    public IdleState(EnemyController obj) : base(obj.gameObject)
    {

    }

    public override Type Tick()
    {
        return null;
    }

}
