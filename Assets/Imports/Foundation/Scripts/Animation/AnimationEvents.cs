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

        public void SetHeadHorizontal(float fAmount)
        {
            GetComponent<Animator>().SetFloat("Head_Horizontal_f", fAmount);
        }

        public void SetBodyHorizontal(float fAmount)
        {
            GetComponent<Animator>().SetFloat("Body_Horizontal_f", fAmount);
        }
    }
}
