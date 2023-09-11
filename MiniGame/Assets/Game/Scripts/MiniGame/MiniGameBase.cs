// ----- C#
using System;
using System.Collections;

// ----- Unity
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

// ----- User Defined
using InGame.ForMiniGame.ForCapture.ForUI;
using InGame.ForMiniGame.ForUI;
using InGame.ForMiniGame.ForCapture;
using Utiltiy.ForLoader;
using InGame.ForState;
using InGame.ForMiniGame.ForControl;

namespace InGame.ForMiniGame
{
    public abstract class MiniGameBase : MonoBehaviour
    {
        // --------------------------------------------------
        // Mini Game State Enum
        // --------------------------------------------------
        public enum EState
        {
            Unknown = 0,
            Init    = 1,
            Intro   = 2,
            Play    = 3,
            Success = 4,
            Fail    = 5,
            Finish  = 6,
        }

        // --------------------------------------------------
        // Components
        // --------------------------------------------------

        [Header("Capture Group")]
        [SerializeField] protected CaptureSystem _captureSystem = null;

        [Header("UI Group")]
        [SerializeField] protected CaptureView   _captureView   = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        protected MiniGameControlBase  _controlBase   = null;
        protected GameView             _gameView      = null;
        protected Coroutine            _co_StateOwner = null;
        protected EState               _gameState     = EState.Unknown;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void ChangeState(EState gameState, Action doneCallBack)
        {
            if (!Enum.IsDefined(typeof(EState), _gameState))
            {
                Debug.LogError($"[MiniControlBase.ChangeState] {Enum.GetName(typeof(EState), gameState)}�� ���ǵǾ����� ���� Enum ���Դϴ�.");
                return;
            }

            if (_gameState == gameState)
                return;

            _gameState = gameState;

            if (_controlBase != null)
                _controlBase.ChangeToCurrentState(_gameState);

            if (_co_StateOwner != null)
                StopCoroutine(_co_StateOwner);

            switch (_gameState)
            {
                case EState.Init:    _co_StateOwner = StartCoroutine(_Co_Init(doneCallBack));    break;
                case EState.Intro:   _co_StateOwner = StartCoroutine(_Co_Intro(doneCallBack));   break;
                case EState.Play:    _co_StateOwner = StartCoroutine(_Co_Play(doneCallBack));    break;
                case EState.Success: _co_StateOwner = StartCoroutine(_Co_Success(doneCallBack)); break;
                case EState.Fail:    _co_StateOwner = StartCoroutine(_Co_Fail(doneCallBack));    break;
                case EState.Finish:  _co_StateOwner = StartCoroutine(_Co_Finish(doneCallBack));  break;
            }
        }

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        protected virtual IEnumerator _Co_Init(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State�� �����Ͽ����ϴ�. </color>");

            _gameView.SetToCloseButton
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

        protected virtual IEnumerator _Co_Intro(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State�� �����Ͽ����ϴ�. </color>");

            _gameView.PlayToCountDown
            (
                () =>
                {
                    ChangeState(EState.Play, null);
                }
            );

            doneCallBack?.Invoke();
            yield return null;
        }

        protected virtual IEnumerator _Co_Play(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State�� �����Ͽ����ϴ�. </color>");

            _gameView.VisiableToTutorial(true);

            // Play Logic Ȱ��ȭ

            doneCallBack?.Invoke();
            yield return null;
        }

        protected virtual IEnumerator _Co_Success(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State�� �����Ͽ����ϴ�. </color>");

            doneCallBack?.Invoke();
            yield return null;
        }

        protected virtual IEnumerator _Co_Fail(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State�� �����Ͽ����ϴ�. </color>");

            doneCallBack?.Invoke();
            yield return null;
        }

        protected virtual IEnumerator _Co_Finish(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State�� �����Ͽ����ϴ�. </color>");

            doneCallBack?.Invoke();
            yield return null;
        }
    }
}