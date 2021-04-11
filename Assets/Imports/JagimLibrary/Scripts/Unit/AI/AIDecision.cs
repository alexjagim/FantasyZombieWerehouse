using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Unit.AI
{
    public abstract class AIDecision : UnityEngine.ScriptableObject
    {
        public abstract bool Decide(StateController controller);
    }
}

