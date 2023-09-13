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
            SlideDown = 3,
        }

        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("1. Text Type")]
        [SerializeField] private TextMeshProUGUI _TMP_Contents    = null;

        [Header("2. Slide Type")]
        [SerializeField] private RectTransform   _RECT_Guage      = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private Coroutine _co_Timer    = null;

        private float     _guageWidth  = 0.0f;
        private float     _guageOrigin = 0.0f;

        private bool      _isInit      = false;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Setting
        public void SetToTimer(int duration = 0)   
        {
            if (_isInit)
                return;

            _isInit = true;
            
            // Text Type
            if (_RECT_Guage == null)
            {
                _TMP_Contents.text = string.Format("{0:00}", duration) + $":00.00";
                return;
            }

            // Slide Type
            _guageOrigin = _RECT_Guage.rect.size.x;
            _guageWidth  = _guageOrigin;
        }
        
        // ----- On/Off
        public void PlayTimer(ECountType countType, float duration, Action doneCallBack) 
        {
            if (_co_Timer != null)
                return;
                
            switch (countType)
            {
                case ECountType.CountUp:   _co_Timer = StartCoroutine(_Co_Timer(ECountType.CountUp,   duration, doneCallBack)); break;
                case ECountType.CountDown: _co_Timer = StartCoroutine(_Co_Timer(ECountType.CountDown, duration, doneCallBack)); break;
                case ECountType.SlideDown: _co_Timer = StartCoroutine(_Co_Timer(duration, doneCallBack)); break;
            }
        }

        public void StopTimer() 
        { 
            if (_co_Timer != null)
            {
                StopCoroutine(_co_Timer);
                _co_Timer = null;
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

                var sec       = Mathf.FloorToInt(elapsedTime);
                var milSec    = Mathf.FloorToInt((elapsedTime * 100) % 100);
                var deciSec   = Mathf.FloorToInt((elapsedTime * 1000) % 10);
                var timerText = string.Format("{0:D2}:{1:D2}.{2:D2}", sec, milSec, deciSec);

                _TMP_Contents.text = timerText;
                
                yield return null;
            }

            _TMP_Contents.text = endText;

            doneCallBack?.Invoke();
            _co_Timer = null;
        }

        private IEnumerator _Co_Timer(float durationSec, Action doneCallBack)
        {
            var startTime   = Time.time;
            var finshTime   = Time.time + durationSec;
            var elapsedTime = 0.0f;
            var size        = _RECT_Guage.rect.size;
            
            while (Time.time < finshTime)
            {
                elapsedTime = Time.time - startTime;
                size.x      = _guageWidth - _guageWidth * elapsedTime / durationSec;

                _RECT_Guage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);

                yield return null;
            }

            size.x = 0f;
            _RECT_Guage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);

            doneCallBack?.Invoke();
            _co_Timer = null;
        }
    }
}