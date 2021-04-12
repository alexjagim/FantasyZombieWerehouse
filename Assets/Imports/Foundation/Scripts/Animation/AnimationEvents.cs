using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Animation
{
    public class AnimationEvents : MonoBehaviour
    {
        public void SetBoolParamaterFalse(string sParameterName)
        {
            GetComponent<Animator>().SetBool(sParameterName, false);
        }
    }
}
