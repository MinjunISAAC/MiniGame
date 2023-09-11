// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

namespace InGame.ForMiniGame.ForCapture.ForUI
{
    public class BlackOut : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private CanvasGroup _canvasGroup = null;
        [SerializeField] private Animation   _animation   = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private Coroutine _co_Play = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void Play(Action doneCallBack)
        {
            if (_co_Play == null)
                _co_Play = StartCoroutine(_Co_Play(doneCallBack));
        }

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        private IEnumerator _Co_Play(Action doneCallBack)
        {
            _animation.Play();

            var hideSec = _animation.clip.length;
            yield return new WaitForSeconds(hideSec);

            doneCallBack?.Invoke();
            _co_Play = null;
        }
    }
}