using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Unit.AI
{
    public abstract class AIAction : UnityEngine.ScriptableObject
    {
        public abstract void Act(StateController controller);
    }
}

