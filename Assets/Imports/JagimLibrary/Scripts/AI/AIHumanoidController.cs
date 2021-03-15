using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.AI;

public class AIHumanoidController : HumanoidController
{
    private float _fKnockbackDistance;
    private Vector3 _vect_KnockbackStart;
    private NavMeshAgent _navMeshAgent;
    private AIStateController _aiStateController;

    protected override void InitVariables()
    {
        base.InitVariables();

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _aiStateController = GetComponent<AIStateController>();
    }

    public override void BeKnockedBack(Transform trans, float fDistance, float fForce)
    {
        base.BeKnockedBack(trans, fDistance, fForce);

        _fKnockbackDistance = fDistance;
        _vect_KnockbackStart = transform.position;

        Vector3 movedirection = transform.position - trans.position;

        _aiStateController.SetAIActive(false);
        _navMeshAgent.enabled = false;
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(movedirection.normalized * fForce);
    }

    protected override void UpdateKnockBack()
    {
        if (Vector3.Distance(transform.position, _vect_KnockbackStart) >= _fKnockbackDistance)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.isKinematic = true;

            _navMeshAgent.enabled = true;
            _aiStateController.SetAIActive(true);

            KnockedBack = false;
        }
    }
}
