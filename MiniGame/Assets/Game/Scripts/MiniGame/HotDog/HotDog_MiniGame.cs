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
using InGame.ForCamera;

namespace InGame.ForMiniGame
{
    public class HotDog_MiniGame : MiniGameBase
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Game Rule")]
        [SerializeField] private float                 _gameDuration  = 10f;
        [SerializeField] private int                   _clearCount    = 0;

        [Header("Control Group")]
        [SerializeField] private TapControl_HotDog     _controller    = null;
        [SerializeField] private TapControlView_HotDog _controlView   = null;

        [Header("Cam Group")]
        [SerializeField] private CamController         _camController = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Private

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        protected override IEnumerator _Co_Init(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _gameView    = (GameView)           _controlView;
            _controlBase = (MiniGameControlBase)_controller;

            _controlView.VisiableToTimer(false);
            _controlView.SetToCloseButton
            (
                () =>
                {
                    Loader.Instance.Visiable
                    (
                        1f,
                        () => { StateMachine.Instance.ChangeState(ForState.EState.Ready, null); },
                        null
                    );
                }
            );

            _captureView.SetToOnClickFinishButton
            (
                () =>
                {
                    Loader.Instance.Visiable
                    (
                        1f,
                        () => { StateMachine.Instance.ChangeState(ForState.EState.Ready, null); },
                        null
                    );
                }
            );

            _controller .SetToClearCount(_clearCount);
            _controller .SetToEatEvent  ((count) => _controlView.RefreshToCount(count));
            
            _controller .onStartEvent  += () => { _controlView.VisiableToTutorial(false); };
            _controller .onFinishEvent += () => { ChangeState(EState.Success, null);      };

            ChangeState(EState.Intro, null);

            doneCallBack?.Invoke();
            yield return null;
        }

        protected override IEnumerator _Co_Intro(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _controlView.PlayToCountDown
            (
                () => 
                { 
                    _camController.Move
                    (
                        true, 0.25f,
                        () => { ChangeState(EState.Play, null); }
                    );
                }
            );

            doneCallBack?.Invoke();
            yield return null;
        }

        protected override IEnumerator _Co_Play(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _controller    .SetToStart        (true);
            
            _charactorAnim .SetTrigger        (IDLE_TRIGGER);
            
            _controlView   .RefreshToCount    (0);
            _controlView   .VisiableToTimer   (true);
            _controlView   .SetToTimer        ((int)_gameDuration);
            _controlView   .VisiableToTutorial(true);
            _controlView   .PlayTimer
            (
                TimerSystem.ECountType.SlideDown,
                _gameDuration,
                () => { ChangeState(EState.Fail, () => { _charactorAnim.ResetTrigger(IDLE_TRIGGER); }); }
            );

            doneCallBack?.Invoke();

            yield return null;
        }

        protected override IEnumerator _Co_Success(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _controlView    .StopTimer ();
            _finishParticle .Play      ();
            _charactorAnim  .SetTrigger(SUCCESS_TRIGGER);
            _camController  .Move      (false, 0.25f, null);

            var delaySec = 3f;
            yield return new WaitForSeconds(delaySec);

            ChangeState(EState.Finish, null);
            doneCallBack?.Invoke();
            
            yield return null;
        }

        protected override IEnumerator _Co_Fail(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            _controlView   .StopTimer           ();
            _controller    .ResetToRuleCount    ();
            _charactorAnim .SetTrigger          (FAIL_TRIGGER);
            _gameView      .VisiableToFailEffect(true);

            var delaySec = 1.5f;
            yield return new WaitForSeconds(delaySec);

            _gameView.VisiableToFailEffect(false);

            ChangeState(EState.Play, () => { _charactorAnim.ResetTrigger(FAIL_TRIGGER); });

            doneCallBack?.Invoke();
            yield return null;
        }

        protected override IEnumerator _Co_Finish(Action doneCallBack)
        {
            Debug.Log($"<color=yellow>[MiniGame.ChangeState] {_gameState} State에 진입하였습니다. </color>");

            

            var capturePicture = _captureSystem.Capture();
            
            _captureView   .SetToCapturePhoto(capturePicture);
            _finishParticle.Stop();
            
            doneCallBack?.Invoke();
            yield return null;
        }
    }
}