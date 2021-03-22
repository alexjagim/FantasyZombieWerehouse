using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public List<Ability> abilities;

    public Animator animator;

    [SerializeField]
    private bool[] _bAbilitiesCanTrigger;

    [SerializeField]
    private List<Effect> effects_onAttack;
    [SerializeField]
    private List<Effect> effects_onHit;
    [SerializeField]
    private List<Effect> effects_Continuous;
    [SerializeField]
    private List<Effect> effects_OnCollision;
    [SerializeField]
    private List<Effect> effects_Instant;

    private UnitController controller;

    private void Awake()
    {
        InitializeVariables();
    }

    public virtual void InitializeVariables()
    {
        effects_onAttack = new List<Effect>();
        effects_onHit = new List<Effect>();
        effects_Continuous = new List<Effect>();
        effects_OnCollision = new List<Effect>();
        effects_Instant = new List<Effect>();

        controller = GetComponent<UnitController>();

        _bAbilitiesCanTrigger = new bool[abilities.Count];

        for (int i = 0; i < _bAbilitiesCanTrigger.Length; ++i)
        {
            _bAbilitiesCanTrigger[i] = true;
        }
    }

    private void Start()
    {
        for (int i = 0; i < abilities.Count; ++i)
        {
            if (abilities[i] is OnButtonPressAbility)
            {
                (abilities[i] as OnButtonPressAbility).input = (controller as PlayerHumanoidController).GetInputActions().Player.Interact;
            }
        }
    }


    private void Update()
    {
        UpdateAbilities();
        UpdateEffects();
    }

    public virtual void UpdateAbilities()
    {
        for (int i = 0; i < abilities.Count; ++i)
        {
            abilities[i].Act(this);
        }
    }

    public virtual void UpdateEffects()
    {
        for (int i = 0; i < effects_Continuous.Count; ++i)
        {
            effects_Continuous[i].Act(controller);
        }
    }

    public void AddEffect(Effect effect)
    {
        AbilitySystemEnums.EffectType type = effect.effectType;

        switch (type)
        {
            case AbilitySystemEnums.EffectType.OnAttack:
                {
                    effects_onAttack.Add(effect);
                    break;
                }
            case AbilitySystemEnums.EffectType.OnHit:
                {
                    effects_onHit.Add(effect);
                    GetComponent<UnitController>().actions_OnHit += effect.Act;
                    break;
                }
            case AbilitySystemEnums.EffectType.Continuous:
                {
                    effects_Continuous.Add(effect);
                    break;
                }
            case AbilitySystemEnums.EffectType.OnCollision:
                {
                    effects_OnCollision.Add(effect);
                    break;
                }
            case AbilitySystemEnums.EffectType.Instant:
                {
                    effects_Instant.Add(effect);
                    break;
                }
        }
    }

    public bool GetAbilityCanTrigger(Ability ability)
    {
        return _bAbilitiesCanTrigger[abilities.IndexOf(ability)];
    }

    public IEnumerator StartCooldownTimer(Ability ability, float fCooldown)
    {
        int iTriggerPosition = abilities.IndexOf(ability);

        _bAbilitiesCanTrigger[iTriggerPosition] = false;

        yield return new WaitForSeconds(fCooldown);

        _bAbilitiesCanTrigger[iTriggerPosition] = true;
    }
}
