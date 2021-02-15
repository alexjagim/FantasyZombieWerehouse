using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    protected UnitController controller;

    [SerializeField, LabelText("Movement Speed")]
    protected float fMovementSpeed = 0.0f;

    [SerializeField, LabelText("Current Speed"), ReadOnly]
    protected float fCurrentSpeed;

    protected virtual void InitController()
    {
        controller = new UnitController();
    }

    protected virtual void InitVariables()
    {

    }

    // Start is called before the first frame update
    private void Start()
    {
        InitController();
        InitVariables();

        fCurrentSpeed = fMovementSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    protected virtual void UpdateAnimations()
    {

    }

    protected virtual void UpdateMovement()
    {

    }
}
