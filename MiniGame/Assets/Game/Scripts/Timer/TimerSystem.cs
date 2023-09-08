// ----- C#
using System;
using System.Collections;

// ----- Unity
using UnityEngine;
using TMPro;

namespace InGame.ForMiniGame.ForUI
{
    public class TimerSystem : MonoBehaviour
    {
        // --------------------------------------------------
        // Timer Type Enum
        // --------------------------------------------------
        public enum ECountType
        {
            Unknown   = 0,
            CountUp   = 1,
            CountDown = 2,
        }

        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private TextMeshProUGUI _TMP_Contents = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private Coroutine _co_Timer = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void Timer(ECountType countType, float duration, Action doneCallBack) 
        {
            if (_co_Timer != null)
                return;
                
            switch (countType)
            {
                case ECountType.CountUp:   _co_Timer = StartCoroutine(_Co_Timer(ECountType.CountUp,   duration, doneCallBack)); break;
                case ECountType.CountDown: _co_Timer = StartCoroutine(_Co_Timer(ECountType.CountDown, duration, doneCallBack)); break;
            }
        } 

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        private IEnumerator _Co_Timer(ECountType countType, float durationSec, Action doneCallBack)
        {
            var startTime = Time.time;
            var finshTime = Time.time + durationSec;
            var endText   = "";

            while (Time.time < finshTime)
            {
                var elapsedTime = 0.0f;

                switch (countType)
                {
                    case ECountType.CountUp:   
                        elapsedTime = Time.time - startTime;
                        endText     = string.Format("{0:00}", durationSec) + $":00.00";
                        break;
                    case ECountType.CountDown: 
                        elapsedTime = finshTime - Time.time;
                        endText     = $"00:00.00";
                        break;
                }

                var sec         = Mathf.FloorToInt(elapsedTime);
                var milSec      = Mathf.FloorToInt((elapsedTime * 100) % 100);
                var deciSec     = Mathf.FloorToInt((elapsedTime * 1000) % 10);
                var timerText   = string.Format("{0:D2}:{1:D2}.{2:D2}", sec, milSec, deciSec);

                _TMP_Contents.text = timerText;
                
                yield return null;
            }

            _TMP_Contents.text = endText;

            doneCallBack?.Invoke();
            _co_Timer = null;
        }
    }
}