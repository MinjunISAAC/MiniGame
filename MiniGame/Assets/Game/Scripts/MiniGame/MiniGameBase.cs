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
        [SerializeField] protected CaptureSystem  _captureSystem  = null;

        [Header("UI Group")]
        [SerializeField] protected CaptureView    _captureView    = null;

        [Header("Charactor Group")]
        [SerializeField] protected Animator       _charactorAnim  = null;

        [Header("Fx Group")]
        [SerializeField] protected ParticleSystem _finishParticle = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Const
        protected const string IDLE_TRIGGER    = "Idle";
        protected const string SUCCESS_TRIGGER = "Finish";
        protected const string FAIL_TRIGGER    = "Fail";

        // ----- Protected
        protected MiniGameControlBase  _controlBase   = null;
        protected GameView             _gameView      = null;
        protected Coroutine            _co_StateOwner = null;
        protected EState               _gameState     = EState.Unknown;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void ChangeState(EState gameState, Action doneCallBack)
        {
            Debug.Log($"Call 0");
            if (!Enum.IsDefined(typeof(EState), _gameState))
            {
                Debug.LogError($"[MiniControlBase.ChangeState] {Enum.GetName(typeof(EState), gameState)}은 정의되어있지 않은 Enum 값입니다.");
                return;
            }

            Debug.Log($"Call 1");
            if (_gameState == gameState)
            {
                Debug.Log($"Call 2");
                return;
            }

            _gameState = gameState;

            if (_controlBase != null)
            {
                _controlBase.ChangeToCurrentState(_gameState);
                Debug.Log($"Call 3");
            }

            if (_co_StateOwner != null)
            {
                StopCoroutine(_co_StateOwner);
                Debug.Log($"Call 4");
            }

            Debug.Log($"Call 5");
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
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _gameView.SetToCloseButton
            (
                () =>
                {
                    Loader.Instance.Visiable
                    (
                        3f, () => { StateMachine.Instance.ChangeState(ForState.EState.Ready, null); }, null
                    );
                }
            );

            ChangeState(EState.Intro, null);
            doneCallBack?.Invoke();
            yield return null;
        }

        protected virtual IEnumerator _Co_Intro(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

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
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _gameView.VisiableToTutorial(true);

            // Play Logic 활성화

            doneCallBack?.Invoke();
            yield return null;
        }

        protected virtual IEnumerator _Co_Success(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            doneCallBack?.Invoke();
            yield return null;
        }

        protected virtual IEnumerator _Co_Fail(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            doneCallBack?.Invoke();
            yield return null;
        }

        protected virtual IEnumerator _Co_Finish(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            doneCallBack?.Invoke();
            yield return null;
        }
    }
}