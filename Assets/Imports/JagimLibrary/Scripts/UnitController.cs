﻿using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class UnitController : MonoBehaviour
{
    [SerializeField, LabelText("Current: "), HorizontalGroup("Health", LabelWidth = 50, Title = "Health")]
    private int _iCurrentHealth;

    [SerializeField, LabelText("Max: "), HorizontalGroup("Health"), LabelWidth(30)]
    private int _iMaxHealth;

    [SerializeField, LabelText("Current: "), HorizontalGroup("Stamina", LabelWidth = 50, Title = "Stamina")]
    private int _iCurrentStamina;

    [SerializeField, LabelText("Max: "), HorizontalGroup("Stamina"), LabelWidth(30)]
    private int _iMaxStamina;

    public event Action action_OnDestroy;

    private void Awake()
    {
        InitInputActions();
    }

    protected virtual void InitInputActions()
    {

    }

    private void Start()
    {
        InitVariables();
    }

    protected virtual void InitVariables()
    {
        _iCurrentHealth = _iMaxHealth;
    }

    public void TakeDamage(int iDamage)
    {
        _iCurrentHealth -= iDamage;

        if (_iCurrentHealth <= 0)
        {
            DestroyUnit();
        }
    }

    public int GetCurrentHealth()
    {
        return _iCurrentHealth;
    }

    private void Update()
    {
        if (_iCurrentHealth <= 0)
        {
            DestroyUnit();
        }

        UpdateObject();
    }

    protected virtual void UpdateObject()
    {

    }

    protected virtual void DestroyUnit()
    {
        action_OnDestroy?.Invoke();
        Destroy(gameObject);
    }
}
