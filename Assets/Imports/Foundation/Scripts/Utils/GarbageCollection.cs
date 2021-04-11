using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Utils
{
    public class GarbageCollection : MonoBehaviour
    {
        [SerializeField, LabelText("Destroy Parent Objects")]
        private bool _bDestroyParentObjects;

        [SerializeField, LabelText("Tags")]
        private List<string> _list_sTags;

        private void OnTriggerEnter(Collider other)
        {
            GameObject obj = other.gameObject;

            if (_list_sTags.Contains(other.tag))
            {
                PreTriggerAction(obj);

                if (_bDestroyParentObjects)
                {
                    while (obj.transform.parent != null)
                    {
                        obj = obj.transform.parent.gameObject;
                    }

                    Destroy(obj);
                }
                else
                {
                    Destroy(other.gameObject);
                }
            }
        }

        protected virtual void PreTriggerAction(GameObject collisionObject)
        {

        }
    }
}