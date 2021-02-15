using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerHumanoidController : PlayerController
{
    [SerializeField, Required("Game Manager needed for Player Controller")]
    private GameManager _gameManager;

    [SerializeField, LabelText("Locked on Enemy")]
    private bool _bIsLockedOntoEnemy;

    private bool _bCanMove;

    public bool IsLockedOntoEnemy
    {
        private set
        {
            _bIsLockedOntoEnemy = value;
        }
        get
        {
            return _bIsLockedOntoEnemy;
        }
    }

    public bool CanMove
    {
        get
        {
            return _bCanMove;
        }
        set
        {
            _bCanMove = value;
        }
    }

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
    }

    private void Start()
    {
        if (_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        IsLockedOntoEnemy = false;
        CanMove = true;
    }

    public GameManager GetGameManager()
    {
        return _gameManager;
    }

    public void ToggleIsLockedOntoEnemy()
    {
        IsLockedOntoEnemy = !IsLockedOntoEnemy;
    }

    protected override void DestroyUnit()
    {

    }
}
