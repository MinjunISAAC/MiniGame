// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

namespace InGame.ForMiniGame.ForCapture.ForUI
{
    public class CaptureView : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private BlackOut _blackOut = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void PlayBlackOut(Action doneCallBack)
        {
            if (_blackOut == null)
            {
                Debug.LogError($"<color=red>[CaptureView.PlayBlackOut] Black Out ������Ʈ�� �������� �ʽ��ϴ�.</color>");
                return;
            }

            _blackOut.Play(doneCallBack);
        }
    }
}