using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Utils
{
    [RequireComponent(typeof(Transform))]
    public class MoveDirectionForward : MonoBehaviour
    {
        [SerializeField, LabelText("Speed")]
        protected float _fSpeed;

        private void Awake()
        {
            InitActions();
        }

        void Update()
        {
            UpdateObject();
        }

        protected virtual void UpdateObject()
        {
            transform.position += (transform.forward * _fSpeed * Time.deltaTime);
        }

        protected virtual void InitActions()
        {

        }
    }
}