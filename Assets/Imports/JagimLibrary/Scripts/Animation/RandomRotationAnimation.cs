using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(Rigidbody))]
public class RandomRotationAnimation : MonoBehaviour
{
    [SerializeField, LabelText("Rotation Speed)")]
    private float _fRotationSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * _fRotationSpeed;
    }
}
