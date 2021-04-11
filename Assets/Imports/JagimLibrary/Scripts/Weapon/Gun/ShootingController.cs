using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ShootingController : MonoBehaviour
{
    [SerializeField, LabelText("Projectile Prefab")]
    protected GameObject _obj_Projectile;
    [SerializeField, LabelText("Projectile Spawn Point")]
    protected Transform _trans_ProjectileSpawnPosition;

    protected virtual void Shoot()
    {
        Instantiate(_obj_Projectile, GetInstantiationPosition(), GetInstantiationRotation());
    }

    protected virtual Vector3 GetInstantiationPosition()
    {
        return _trans_ProjectileSpawnPosition.position;
    }

    protected virtual Quaternion GetInstantiationRotation()
    {
        return Quaternion.identity;
    }
}
