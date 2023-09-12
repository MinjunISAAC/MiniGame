// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

namespace InGame.ForMiniGame.ForUI
{
    public class MiniGameUnit : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Mini Game Type")]
        [SerializeField] private EMiniGameType _miniGameType      = EMiniGameType.Unknown;

        [Header("UI Group")]
        [SerializeField] private Button        _BTN_EnterMiniGame = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public EMiniGameType MiniGameType => _miniGameType;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void OnDestroy()
        {
            _BTN_EnterMiniGame.onClick.RemoveAllListeners();
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void SetOnClickEvent(Action<EMiniGameType> onClickBtn)
        {
            _BTN_EnterMiniGame.onClick.AddListener(() => { onClickBtn?.Invoke(_miniGameType); });
        }
    }
}