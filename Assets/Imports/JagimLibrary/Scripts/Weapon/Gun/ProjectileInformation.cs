using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ProjectileInformation : MonoBehaviour
{
    [SerializeField, LabelText("Damage")]
    private int _iDamage;
    [SerializeField, LabelText("Speed")]
    private float _fSpeed;

    public int Damage
    {
        get
        {
            return _iDamage;
        }
        set
        {
            _iDamage = value;
        }
    }

    public float Speed
    {
        get
        {
            return _fSpeed;
        }
        set
        {
            _fSpeed = value;
        }
    }
}
