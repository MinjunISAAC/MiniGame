// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined

namespace InGame.ForMiniGame.ForUI
{
    public class TapControlView : GameView
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private TimerSystem _timerSystem = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void SetToTimer(int sec) =>
            _timerSystem.SetToTimer(sec);

        public void PlayTimer(TimerSystem.ECountType countType, float duration, Action doneCallBack) =>
            _timerSystem.PlayTimer(countType, duration, doneCallBack);

        public void StopTimer() => _timerSystem.StopTimer();
    }
}