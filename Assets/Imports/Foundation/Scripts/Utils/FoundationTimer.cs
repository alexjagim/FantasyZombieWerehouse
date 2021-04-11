using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Utils
{
    public class FoundationTimer
    {
        private float _fDuration;
        private bool _bTimerComplete;

        public FoundationTimer(float fDuration)
        {
            _fDuration = fDuration;
            _bTimerComplete = false;
        }

        public void TimerStart()
        {
            _bTimerComplete = false;
            StartTimerCoroutine();
        }

        public bool TimerComplete()
        {
            return _bTimerComplete;
        }

        private IEnumerator StartTimerCoroutine()
        {
            yield return new WaitForSeconds(_fDuration);

            _bTimerComplete = true;
        }
    }
}