// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

namespace InGame.ForMiniGame.ForControl
{
    public class TapControl : MiniGameControlBase
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Control Value Group")]
        [SerializeField] private float _tapInterval = 0.0f;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private bool _isStart = false;

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
                Debug.Log($"Click");
            }
        }

        // ----- Public
        public void SetToStart(bool isStart) => _isStart = isStart;
    }
}