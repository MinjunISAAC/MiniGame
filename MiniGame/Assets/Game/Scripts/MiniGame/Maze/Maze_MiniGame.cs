// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utiltiy.ForLoader;
using InGame.ForMiniGame.ForUI;
using InGame.ForState;

namespace InGame.ForMiniGame
{
    public class Maze_MiniGame : MiniGameBase
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Game Rule")]
        [SerializeField] private int             _gameDuration = 10;
        
        [Header("Control Group")]
        [SerializeField] private DrawControlView _controlView = null;

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        protected override IEnumerator _Co_Init(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _gameView = (GameView)_controlView;

            _controlView.SetToCloseButton
            (
                () =>
                {
                    Loader.Instance.Visiable
                    (
                        3f, () => { StateMachine.Instance.ChangeState(ForState.EState.Ready, null); }
                    );
                }
            );

            ChangeState(EState.Intro, null);
            doneCallBack?.Invoke();
            yield return null;
        }

        protected override IEnumerator _Co_Intro(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _controlView.SetToTimer(_gameDuration);
            _controlView.PlayToCountDown
            (
                () =>
                {
                    ChangeState(EState.Play, null);
                }
            );

            doneCallBack?.Invoke();
            yield return null;
        }

        protected override IEnumerator _Co_Play(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _controlView.VisiableToTutorial(true);
            _controlView.PlayTimer
            (
                TimerSystem.ECountType.CountDown,
                _gameDuration,
                () => { Debug.Log($"Game ENd"); }
            );

            // Play Logic 활성화

            doneCallBack?.Invoke();
            yield return null;
        }
    }
}