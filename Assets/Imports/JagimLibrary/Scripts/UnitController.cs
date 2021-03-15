using UnityEngine;
using Sirenix.OdinInspector;
using System;
using System.Collections;

public class UnitController : MonoBehaviour
{
    [SerializeField, LabelText("Current: "), BoxGroup("Base Variables"), HorizontalGroup("Base Variables/Health", LabelWidth = 50, Title = "Health")]
    private int _iCurrentHealth;

    [SerializeField, LabelText("Max: "), BoxGroup("Base Variables"), HorizontalGroup("Base Variables/Health"), LabelWidth(30)]
    private int _iMaxHealth;

    [SerializeField, LabelText("Current: "), BoxGroup("Base Variables"), HorizontalGroup("Base Variables/Stamina", LabelWidth = 50, Title = "Stamina")]
    private int _iCurrentStamina;

    [SerializeField, LabelText("Max: "), BoxGroup("Base Variables"), HorizontalGroup("Base Variables/Stamina"), LabelWidth(30)]
    private int _iMaxStamina;

    private Material _material_Original;

    [SerializeField, LabelText("Skinned Mesh Renderer"), BoxGroup("Base Variables"), Title("Damage Animation")]
    private SkinnedMeshRenderer _skinnedMeshRenderer;

    [SerializeField, LabelText("Damage Material"), BoxGroup("Base Variables")]
    private Material _material_Damage;

    [SerializeField, LabelText("Animation Delay"), BoxGroup("Base Variables")]
    private float _fDamageAnimationDelay;
    [SerializeField, LabelText("Animation Duration"), BoxGroup("Base Variables")]
    private float _fDamageAnimationDuration;

    public event Action action_OnDestroy;

    private bool _bKnockedBack;

    protected bool KnockedBack
    {
        get
        {
            return _bKnockedBack;
        }
        set
        {
            _bKnockedBack = value;
        }
    }

    private void Awake()
    {
        InitInputActions();
    }

    protected virtual void InitInputActions()
    {

    }

    private void Start()
    {
        InitVariables();
    }

    protected virtual void InitVariables()
    {
        _iCurrentHealth = _iMaxHealth;
        _material_Original = _skinnedMeshRenderer.material;
        _bKnockedBack = false;
    }

    public void TakeDamage(int iDamage)
    {
        _iCurrentHealth -= iDamage;

        //Clears out in the attack happens again before the damage flash is complete
        StopCoroutine("FlashObject");
        StartCoroutine(FlashObject(_skinnedMeshRenderer, _material_Original, _material_Damage, _fDamageAnimationDuration, _fDamageAnimationDelay));
    }

    public virtual void BeKnockedBack(Transform trans, float fDistance, float fForce)
    {
        _bKnockedBack = true;
    }

    protected virtual void UpdateKnockBack()
    {
        _bKnockedBack = false;
    }

    protected virtual void DamageAnimation()
    {
        //FlashObject(_skinnedMeshRenderer, _material_Original, _material_Damage, 1.0f, 1.0f);
    }

    public int GetCurrentHealth()
    {
        return _iCurrentHealth;
    }

    private void Update()
    {
        if (_iCurrentHealth <= 0)
        {
            DestroyUnit();
        }

        UpdateObject();
    }

    protected virtual void UpdateObject()
    {
        if (_bKnockedBack)
        {
            UpdateKnockBack();
        }
    }

    protected virtual void DestroyUnit()
    {
        action_OnDestroy?.Invoke();
        Destroy(gameObject);
    }

    private IEnumerator FlashObject(SkinnedMeshRenderer toFlash, Material originalMaterial, Material flashMaterial, float flashTime, float flashDelay)
    {
        float flashingFor = 0;
        Material newColor = flashMaterial;

        yield return new WaitForSeconds(flashDelay);

        toFlash.material = newColor;
        flashingFor += Time.deltaTime;

        yield return new WaitForSeconds(flashTime);

        toFlash.material = originalMaterial;
    }
}
