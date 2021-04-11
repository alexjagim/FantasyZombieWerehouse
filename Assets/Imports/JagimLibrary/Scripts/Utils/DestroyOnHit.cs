using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Utils
{
    public class DestroyOnHit : MonoBehaviour
    {
        [SerializeField, LabelText("Destroy Parent Objects")]
        private bool _bDestroyParentObjects;

        [SerializeField, LabelText("Tags")]
        private List<string> _list_sTags;

        private void OnTriggerEnter(Collider other)
        {
            if (_list_sTags.Contains(other.tag))
            {
                ActionsBeforeBeingDestroyed(other.gameObject);

                DestroyObjectContainingTag(other.gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_list_sTags.Contains(collision.transform.tag))
            {
                ActionsBeforeBeingDestroyed(collision.gameObject);

                DestroyObjectContainingTag(collision.gameObject);
            }
        }

        private void DestroyObjectContainingTag(GameObject obj)
        {
            GameObject obj_Temp = this.gameObject;

            if (_bDestroyParentObjects)
            {
                while (obj_Temp.transform.parent != null)
                {
                    obj_Temp = obj_Temp.transform.parent.gameObject;
                }

                Destroy(obj_Temp);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        protected virtual void ActionsBeforeBeingDestroyed(GameObject CollisionObject)
        {

        }
    }
}