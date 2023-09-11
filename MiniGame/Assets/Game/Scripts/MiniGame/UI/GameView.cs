// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

// ----- User Defined

namespace InGame.ForMiniGame.ForUI
{
    public abstract class GameView : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Animation Group")]
        [SerializeField] protected Animation _countDownAnim = null;
        [SerializeField] protected Animation _tutorialAnim  = null;

        [Header("UI Group")]
        [SerializeField] protected Button    _BTN_Close = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        protected Coroutine _co_CountDown = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void SetToCloseButton(Action onClickCloseBtn)
        {
            _BTN_Close.onClick.AddListener(() => onClickCloseBtn());
        }

        public void PlayToCountDown(Action doneCallBack)
        {
            if (_co_CountDown == null)
                _co_CountDown = StartCoroutine(_Co_PlayCountDown(doneCallBack));
        }

        public void VisiableToTutorial(bool isShow)
        {
            if (isShow)
            {
                _tutorialAnim.gameObject.SetActive(isShow);
                _tutorialAnim.Play();
            }
            else
            {
                _tutorialAnim.Stop();
                _tutorialAnim.gameObject.SetActive(isShow);
            } 
        }

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        protected IEnumerator _Co_PlayCountDown(Action doneCallBack)
        {
            _countDownAnim.Play();

            var countDownSec = _countDownAnim.clip.length;
            yield return new WaitForSeconds(countDownSec);

            doneCallBack?.Invoke();
            _co_CountDown = null;
        }
    }
}