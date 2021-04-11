using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Foundation.Unit;
using Foundation.Unit.Ability.ScriptableObject;
using Foundation.Unit.Player.Humanoid;

namespace Foundation.Unit.Ability
{
    public class AbilityController : MonoBehaviour
    {
        public List<Ability> abilities;

        public Animator animator;

        [SerializeField, ReadOnly]
        private bool[] _bAbilitiesCanTrigger;

        [SerializeField, ReadOnly]
        private bool[] _bAbilitiesAreToggledOn;

        [SerializeField, ReadOnly]
        private List<Effect> effects_onAttack;
        [SerializeField, ReadOnly]
        private List<Effect> effects_onHit;
        [SerializeField, ReadOnly]
        private List<Effect> effects_Continuous;
        [SerializeField, ReadOnly]
        private List<Effect> effects_OnCollision;

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

            controller = GetComponent<UnitController>();

            _bAbilitiesCanTrigger = new bool[abilities.Count];
            _bAbilitiesAreToggledOn = new bool[abilities.Count];

            for (int i = 0; i < _bAbilitiesCanTrigger.Length; ++i)
            {
                _bAbilitiesCanTrigger[i] = true;
                _bAbilitiesAreToggledOn[i] = false;
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
                        effect.Act(controller);
                        break;
                    }
            }
        }

        public void RemoveEffect(Effect effect)
        {
            AbilitySystemEnums.EffectType type = effect.effectType;

            switch (type)
            {
                case AbilitySystemEnums.EffectType.OnAttack:
                    {
                        effects_onAttack.Remove(effect);
                        break;
                    }
                case AbilitySystemEnums.EffectType.OnHit:
                    {
                        effects_onHit.Remove(effect);
                        GetComponent<UnitController>().actions_OnHit -= effect.Act;
                        break;
                    }
                case AbilitySystemEnums.EffectType.Continuous:
                    {
                        effects_Continuous.Remove(effect);
                        break;
                    }
                case AbilitySystemEnums.EffectType.OnCollision:
                    {
                        effects_OnCollision.Remove(effect);
                        break;
                    }
                case AbilitySystemEnums.EffectType.Instant:
                    {
                        break;
                    }
            }
        }

        public bool GetAbilityCanTrigger(Ability ability)
        {
            return _bAbilitiesCanTrigger[abilities.IndexOf(ability)];
        }

        public bool GetAbilityIsToggledOn(Ability ability)
        {
            return _bAbilitiesAreToggledOn[abilities.IndexOf(ability)];
        }

        public void SetAbilityIsToggledOn(Ability ability, bool bToggledOn)
        {
            _bAbilitiesAreToggledOn[abilities.IndexOf(ability)] = bToggledOn;
        }

        public UnitController GetUnitController()
        {
            return controller;
        }

        public void StartCooldownTimer(Ability ability, float fCooldown)
        {
            StartCoroutine(StartCoroutineCooldownTimer(ability, fCooldown));
        }

        private IEnumerator StartCoroutineCooldownTimer(Ability ability, float fCooldown)
        {
            Debug.Log("Cooldown Timer Started");
            int iTriggerPosition = abilities.IndexOf(ability);

            _bAbilitiesCanTrigger[iTriggerPosition] = false;

            yield return new WaitForSeconds(fCooldown);

            _bAbilitiesCanTrigger[iTriggerPosition] = true;
        }

        public void StartStaminaReductionTimer(Ability ability, int iAmountPerSecond)
        {
            StartCoroutine(StartCoroutineStaminaReductionTimer(ability, iAmountPerSecond));
        }

        private IEnumerator StartCoroutineStaminaReductionTimer(Ability ability, int iAmountPerSecond)
        {
            Debug.Log("Stamina Timer Started");
            controller.ReduceStamina(iAmountPerSecond);

            yield return new WaitForSeconds(1);

            if (_bAbilitiesAreToggledOn[abilities.IndexOf(ability)] && controller.GetCurrentStamina() > iAmountPerSecond)
            {
                StartStaminaReductionTimer(ability, iAmountPerSecond);
            }
            else
            {
                (ability as OnButtonPressToggleAbility).ForceAbilityOff(this);
            }
        }
    }
}

