using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ItemDrop : MonoBehaviour
{
    [SerializeField, LabelText("Items That Can Drop"), Required]
    private List<GameObject> obj_ItemsThatCanDrop;

    [SerializeField, LabelText("Item to Drop"), ReadOnly]
    private GameObject obj_Item = null;

    private void Start()
    {
        DetermineItemDrop();

        GetComponent<AIController>().action_OnDestroy += DropItem;
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
