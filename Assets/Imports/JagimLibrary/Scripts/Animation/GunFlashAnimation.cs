using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Animation
{
    public class GunFlashAnimation : MonoBehaviour
    {
        [SerializeField, LabelText("Duration")]
        private float _fDuration;

        private Material _material;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }

        public void TriggerGunFlash()
        {

        }
    }
}
