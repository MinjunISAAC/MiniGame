// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utiltiy.ForLoader;
using InGame.ForMiniGame;
using InGame.ForMiniGame.ForUI;

namespace InGame.ForMiniGame
{
    public class HotDog_MiniGame : MiniGameBase
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Game Rule")]
        [SerializeField] private float          _gameDuration = 10f;

        [Header("Control Group")]
        [SerializeField] private TapControlView _controlView  = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Private

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void Start()
        {
            
        }

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        protected override IEnumerator _Co_Init(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _gameView    = (GameView)_controlView;
            _controlView.SetToTimer((int)_gameDuration);
            _controlView.PlayToCountDown
            (
                () =>
                {
                    ChangeState(EState.Intro, null);
                }
            );

            //_controlBase = (MiniGameControlBase)_controller;

            doneCallBack?.Invoke();
            yield return null;
        }

        protected override IEnumerator _Co_Intro(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _controlView.PlayTimer
            (
                TimerSystem.ECountType.SlideDown,
                _gameDuration,
                () => { ChangeState(EState.Fail, () => { _charactorAnim.ResetTrigger(IDLE_TRIGGER); }); }
            );

            doneCallBack?.Invoke();
            yield return null;
        }

        protected override IEnumerator _Co_Play(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            doneCallBack?.Invoke();
            yield return null;
        }

        protected override IEnumerator _Co_Success(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            doneCallBack?.Invoke();
            yield return null;
        }

        protected override IEnumerator _Co_Fail(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            doneCallBack?.Invoke();
            yield return null;
        }

        protected override IEnumerator _Co_Finish(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            doneCallBack?.Invoke();
            yield return null;
        }
    }
}