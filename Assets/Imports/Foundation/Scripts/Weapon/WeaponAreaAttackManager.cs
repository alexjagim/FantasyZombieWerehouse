using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Weapon
{
    public class WeaponAreaAttackManager : MonoBehaviour
    {
        [SerializeField, LabelText("Collider")]
        public Collider _collider;

        [SerializeField, LabelText("Tags")]
        public List<string> _list_Tags;

        [ReadOnly]
        public List<GameObject> _list_ObjectsInArea;

        private void Update()
        {
            for (int i = 0; i < _list_ObjectsInArea.Count; ++i)
            {
                if (_list_ObjectsInArea[i] == null)
                {
                    _list_ObjectsInArea.RemoveAt(i);

                    i--;
                }
            }
        }
    }
}

