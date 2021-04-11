using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Unit.AI.ScriptableObject
{
    [CreateAssetMenu(menuName = "Pluggable/AI/Actions/Attack")]
    public class AttackAction : AIAction
    {
        public override void Act(StateController controller)
        {
            Attack(controller);
        }

        private void Attack(StateController controller)
        {
            controller.GetComponent<AIWeaponHandler>().TriggerAttack();
        }
    }
}