using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitController
{
    protected PlayerInputActions _inputActions;

    protected override void InitInputActions()
    {
        base.InitInputActions();

        _inputActions = new PlayerInputActions();
    }

    public PlayerInputActions GetInputActions()
    {
        return _inputActions;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }
}
