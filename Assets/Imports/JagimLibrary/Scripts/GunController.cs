using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GunController : MonoBehaviour
{
    [LabelText("Gun Flash Object"), ChildGameObjectsOnly]
    public GameObject GunFlash;

    [LabelText("Bullet Spawn Position"), ChildGameObjectsOnly]
    public Transform trans_BulletSpawn;

    public int iNumberOfClipsRemaining
    {
        get; set;
    }

    public int iNumberOfShotsRemaining
    {
        get; set;
    }

    public void PlayGunFireAnimation()
    {
        GunFlash.GetComponent<GunFlashAnimation>().TriggerGunFlash();
    }
}
