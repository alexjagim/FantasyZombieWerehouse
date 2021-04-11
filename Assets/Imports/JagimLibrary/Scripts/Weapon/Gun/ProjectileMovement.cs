using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(ProjectileInformation))]
public class ProjectileMovement : MoveDirectionForward
{
    [SerializeField, LabelText("Auto Destroy With Distance"), LabelWidth(160.0f)]
    private bool _bAutoDestroy;

    [SerializeField, LabelText("Max Distance"), ShowIf("_bAutoDestroy")]
    private float _fMaxDistance;

    private Vector3 _pos_Initial;

    [SerializeField, LabelText("Current Distance"), ShowIf("_bAutoDestroy"), ReadOnly]
    private float _fCurrentDistance;

    protected override void InitActions()
    {
        base.InitActions();

        _fSpeed = GetComponent<ProjectileInformation>().Speed;

        _pos_Initial = transform.position;
    }

    protected override void UpdateObject()
    {
        base.UpdateObject();

        if(_bAutoDestroy)
        {
            _fCurrentDistance = Vector3.Distance(transform.position, _pos_Initial);

            if (_fCurrentDistance >= _fMaxDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}
