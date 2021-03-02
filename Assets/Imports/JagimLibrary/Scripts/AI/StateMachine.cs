using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine
{
    private Dictionary<Type, BaseState> _availableStates;

    public BaseState CurrentState { get; private set; }

    public event Action<BaseState> OnStateChanged;

    public StateMachine(Dictionary<Type, BaseState> states)
    {
        SetStates(states);
    }

    public void SetStates(Dictionary<Type, BaseState> states)
    {
        _availableStates = states;
    }

    public void Update()
    {
        if (CurrentState == null)
        {
            CurrentState = _availableStates.Values.First();
        }

        var nextState = CurrentState?.Tick();

        if (nextState != null && nextState != CurrentState?.GetType())
        {
            SwitchToNewState(nextState);
        }
    }

    private void SwitchToNewState(Type nextState)
    {
        CurrentState = _availableStates[nextState];
        OnStateChanged?.Invoke(CurrentState);
    }
}
