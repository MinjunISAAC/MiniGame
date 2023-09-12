// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

namespace InGame.ForCamera
{
    public class CamController : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Camera Group")]
        [SerializeField] private Camera    _mainCamera  = null;

        [Header("Target Position Group")]
        [SerializeField] private Transform _startTrans  = null;
        [SerializeField] private Transform _endTrans    = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private Coroutine _co_Cam = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void ActivedToMainCam(bool active)
        {
            _mainCamera.gameObject.SetActive(active);
        }

        public void Move(bool isEnlarge, float duration, Action doneCallBack)
        {
            Transform target = null;

            if (isEnlarge) target = _endTrans;
            else           target = _startTrans;

            if (_co_Cam == null)
                _co_Cam = StartCoroutine(_Co_Move(duration, target, doneCallBack));
        }

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        private IEnumerator _Co_Move(float duration, Transform targetTrans, Action doneCallBack)
        {
            var sec      = 0.0f;
            var startPos = _mainCamera.transform.position;
            var endPos   = targetTrans.position;

            while (sec < duration)
            {
                sec += Time.deltaTime;
                _mainCamera.transform.position = Vector3.Lerp(startPos, endPos, sec / duration);
                yield return null;
            }

            _mainCamera.transform.position = endPos;
            doneCallBack?.Invoke();
            _co_Cam = null;
        }
    }
}