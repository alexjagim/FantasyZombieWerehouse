using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanoidController))]
public class PlayerShootingController : ShootingController
{
    private PlayerInputActions _inputActions;

    private void Start()
    {
        _inputActions = GetComponent<PlayerHumanoidController>().GetInputActions();
    }

    private void Update()
    {
        if(_inputActions.Player.Attack.triggered)
        {
            Shoot();
        }
    }

    protected override Quaternion GetInstantiationRotation()
    {
        return Quaternion.identity * Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f));
    }
}
