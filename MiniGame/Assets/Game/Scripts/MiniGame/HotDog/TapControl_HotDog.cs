// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

namespace InGame.ForMiniGame.ForControl
{
    public class TapControl_HotDog : TapControl
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Game Rule")]
        [SerializeField] private int       _hotDogCount      = 0;
        
        [Header("Image Group")]
        [SerializeField] private Image     _IMG_HotDogOrigin = null;

        [Header("Position Group")]
        [SerializeField] private Transform _hotDogParents    = null;
        [SerializeField] private Transform _hotDogTarget     = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Protected
        protected override void UpdateToPlay()
        {
            if (!_isStart)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                var pos    = Input.mousePosition;
                    pos.z  = 1f;
                var imgPos = Camera.main.ScreenToWorldPoint(pos);
                var hotDog = Instantiate(_IMG_HotDogOrigin, _hotDogParents);

                hotDog.transform.position = imgPos;
                StartCoroutine(_Co_MoveToHotDog(hotDog.GetComponent<RectTransform>(), 0.25f, null));
            }
        }

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
        private IEnumerator _Co_MoveToHotDog(RectTransform targetRect, float duration, Action doneCallBack)
        {
            var sec         = 0.0f;
            var startPos    = targetRect.anchoredPosition;
            var endPos      = Camera.main.ScreenToWorldPoint(_hotDogTarget.position);
            var startScale  = targetRect.transform.localScale;
            var endScale    = new Vector3(0.2f, 0.2f, 0.2f);
            var randomValue = UnityEngine.Random.Range(0.5f, 2f);

            while (sec < duration)
            {
                sec += Time.deltaTime;

                targetRect.transform.Rotate(0f,0f, randomValue);
                targetRect.anchoredPosition     = Vector2.Lerp(startPos,   endPos,   sec / duration);
                targetRect.transform.localScale = Vector3.Lerp(startScale, endScale, sec / duration); 

                yield return null;
            }

            targetRect.transform.localScale = Vector3.zero;
            targetRect.anchoredPosition     = endPos;
            doneCallBack?.Invoke();
        }
    }
}