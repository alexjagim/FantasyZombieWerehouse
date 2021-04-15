using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Animation
{
    public class RotationAnimation : MonoBehaviour
    {
        [SerializeField, LabelText("Rotation Speed")]
        private float _fRotationSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.forward * _fRotationSpeed * Time.deltaTime);
        }
    }
}
