using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DestroyOnHitWithDamage : DestroyOnHit
{
    [SerializeField, LabelText("Damage")]
    private int _iDamage;

    protected override void ActionsBeforeBeingDestroyed(GameObject CollisionObject)
    {
        base.ActionsBeforeBeingDestroyed(CollisionObject);

        if (CollisionObject.TryGetComponent<UnitController>(out UnitController controller))
        {
            CollisionObject.GetComponent<UnitController>().TakeDamage(_iDamage);
        }
        else
        {
            CollisionObject.GetComponentInParent<UnitController>().TakeDamage(_iDamage);
        }
    }
}
