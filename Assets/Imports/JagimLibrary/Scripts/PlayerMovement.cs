using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : UnitMovement
{
    protected PlayerInputActions _inputActions;
    protected Rigidbody _rigidbody;

    protected override void InitController()
    {
        base.InitController();

        controller = GetComponent<PlayerController>();
    }

    protected override void InitVariables()
    {
        base.InitVariables();

        _inputActions = (controller as PlayerController).GetInputActions();
        _rigidbody = GetComponent<Rigidbody>();
    }
}
