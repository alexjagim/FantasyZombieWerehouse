using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class HumanoidController : UnitController
{
    [SerializeField, LabelText("Rigidbody"), BoxGroup("Components")]
    protected Rigidbody _rigidbody;
    [SerializeField, LabelText("Animator"), BoxGroup("Components")]
    private Animator _animator;

    [SerializeField, Required("Game Manager needed for Humanoid Controller"), BoxGroup("Components")]
    private GameManager _gameManager;

    [SerializeField, LabelText("Locked on Enemy")]
    private bool _bIsLockedOntoEnemy;

    private bool _bCanMove;
    private bool _bCanRotate;

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

    public bool CanRotate
    {
        get
        {
            return _bCanRotate;
        }
        set
        {
            _bCanRotate = value;
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
        _bCanMove = true;
        _bCanRotate = true;
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
}
