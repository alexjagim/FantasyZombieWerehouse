using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
//using DG.Tweening;

public class GunFlashAnimation : MonoBehaviour
{
    [SerializeField, LabelText("Duration")]
    private float _fDuration;

    private Material _material;
    //private Sequence _sequence;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;

        //_material.DOFade(0.0f, 0.0f);
    }

    public void TriggerGunFlash()
    {
        //_sequence = DOTween.Sequence();
        //_sequence.Append(_material.DOFade(0.5f, _fDuration / 2));
        //_sequence.Append(_material.DOFade(0.0f, _fDuration / 2));
    }
}
