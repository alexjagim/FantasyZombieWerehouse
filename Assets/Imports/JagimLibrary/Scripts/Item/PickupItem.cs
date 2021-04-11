using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupItem : MonoBehaviour
{
    public abstract void Pickup(GameObject obj);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Pickup(other.gameObject);
            Destroy(gameObject);
        }
    }
}
