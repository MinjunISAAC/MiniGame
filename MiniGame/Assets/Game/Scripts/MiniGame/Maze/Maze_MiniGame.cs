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
using InGame.ForMiniGame.ForControl;

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
        [SerializeField] private DrawControl     _controller   = null;
        [SerializeField] private DrawControlView _controlView  = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Private
        private void _ChangeStateToPlay  () => ChangeState(EState.Play,   null);
        private void _ChangeStateToFail  () => ChangeState(EState.Fail,   null);
        private void _ChangeStateToFinish() => ChangeState(EState.Finish, null);

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        protected override IEnumerator _Co_Init(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State�� �����Ͽ����ϴ�. </color>");

            _gameView    = (GameView)           _controlView;
            _controlBase = (MiniGameControlBase)_controller;
                
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

            ColliderEvent.onStartAction  += _ChangeStateToPlay;
            ColliderEvent.onFailAction   += _ChangeStateToFail;
            ColliderEvent.onFinishAction += _ChangeStateToFinish;

            doneCallBack?.Invoke();
            yield return null;
        }

        protected override IEnumerator _Co_Intro(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State�� �����Ͽ����ϴ�. </color>");

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
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State�� �����Ͽ����ϴ�. </color>");

            _controlView.VisiableToTutorial(true);
            _controlView.PlayTimer
            (
                TimerSystem.ECountType.CountDown,
                _gameDuration,
                () => { Debug.Log($"Game ENd"); }
            );

            // Play Logic Ȱ��ȭ

            doneCallBack?.Invoke();
            yield return null;
        }
    }
}