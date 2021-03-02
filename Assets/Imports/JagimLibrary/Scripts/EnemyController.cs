using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyController : UnitController
{
    [SerializeField, LabelText("Target")]
    private Transform _target;

    public Transform Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
        }
    }

    public StateMachine StateMachine;

    protected override void InitVariables()
    {
        base.InitVariables();

        InitializeStateMachine();
    }

    protected override void UpdateObject()
    {
        base.UpdateObject();

        StateMachine.Update();
    }

    protected virtual void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(WanderState), new WanderState(this) },
            { typeof(IdleState), new IdleState(this) },
            { typeof(ChaseState), new ChaseState(this) }
        };

        AddAdditionalStates();

        StateMachine = new StateMachine(states);
    }

    protected virtual void AddAdditionalStates()
    {

    }
}
