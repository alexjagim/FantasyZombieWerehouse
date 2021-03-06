﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Foundation.Unit.AI.Humanoid;

namespace Foundation.Item
{
    public class ItemDrop : MonoBehaviour
    {
        [SerializeField, LabelText("Items That Can Drop"), Required]
        private List<GameObject> obj_ItemsThatCanDrop;

        [SerializeField, LabelText("Item to Drop"), ReadOnly]
        private GameObject obj_Item = null;

        private void Start()
        {
            DetermineItemDrop();

            GetComponent<AIHumanoidController>().actions_OnDestroy += DropItem;
        }

        private void DetermineItemDrop()
        {
            obj_Item = obj_ItemsThatCanDrop[Random.Range(0, obj_ItemsThatCanDrop.Count)];
        }

        private void DropItem()
        {
            GameObject temp = Instantiate(obj_Item);
            temp.transform.position += transform.position;
        }
    }
}

