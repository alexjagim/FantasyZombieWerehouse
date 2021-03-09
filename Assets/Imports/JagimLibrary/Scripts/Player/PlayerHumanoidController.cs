using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerHumanoidController : PlayerController
{
    [SerializeField, LabelText("Rigidbody"), BoxGroup("Components")]
    private Rigidbody _rigidbody;
    [SerializeField, LabelText("Animator"), BoxGroup("Components")]
    private Animator _animator;

    [SerializeField, Required("Game Manager needed for Player Controller"), BoxGroup("Components")]
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

    protected override void InitVariables()
    {
        base.InitVariables();

        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }

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

    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

    public Animator GetAnimator()
    {
        return _animator;
    }

    public void ToggleIsLockedOntoEnemy()
    {
        IsLockedOntoEnemy = !IsLockedOntoEnemy;
    }

    protected override void DestroyUnit()
    {

    }
}
