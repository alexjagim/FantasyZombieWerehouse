using UnityEngine;
using Sirenix.OdinInspector;

namespace Foundation.Animation
{
    [System.Serializable]
    public class AnimationParameterInfo
    {
        [LabelText("ID String")]
        public string sID;
        public AnimatorControllerParameterType parameter;
        [LabelText("Float Value"), ShowIf("@parameter == UnityEngine.AnimatorControllerParameterType.Float")]
        public float fValue;
        [LabelText("Bool Value"), ShowIf("@parameter == UnityEngine.AnimatorControllerParameterType.Bool")]
        public bool bValue;
        [LabelText("Int Value"), ShowIf("@parameter == UnityEngine.AnimatorControllerParameterType.Int")]
        public int iValue;
    }
}

