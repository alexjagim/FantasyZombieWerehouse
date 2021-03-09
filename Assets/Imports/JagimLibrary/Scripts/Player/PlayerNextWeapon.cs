using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHumanoidController)), RequireComponent(typeof(PlayerWeaponHandler))]
public class PlayerNextWeapon : MonoBehaviour
{
    private PlayerWeaponHandler _playerWeaponHandler;
    private PlayerInputActions _inputActions;

    void Start()
    {
        _playerWeaponHandler = GetComponent<PlayerWeaponHandler>();
        _inputActions = GetComponent<PlayerHumanoidController>().GetInputActions();
    }

    void Update()
    {
        if (_inputActions.Player.NextWeapon.triggered)
        {
            _playerWeaponHandler.NextWeapon();
        }
    }
}
