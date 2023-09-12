// ----- C#
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
        [Header("Image Group")]
        [SerializeField] private Image _IMG_HotDogOrigin = null;

        [Header("Position Group")]
        [SerializeField] private Transform _hotDogParents = null;

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
            }
        }

        // --------------------------------------------------
        // Functions - Coroutine
        // --------------------------------------------------
    }
}