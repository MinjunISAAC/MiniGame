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
        [SerializeField] private BlackOut   _blackOut = null;
        [SerializeField] private GameObject _contents = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void PlayBlackOut(Action doneCallBack = null)
        {
            if (_blackOut == null)
            {
                Debug.LogError($"<color=red>[CaptureView.PlayBlackOut] Black Out ������Ʈ�� �������� �ʽ��ϴ�.</color>");
                return;
            }

            _blackOut.Play(doneCallBack);
        }

        public void VisiableToContents(bool isShow) => _contents.SetActive(isShow);

        public void SetToCapturePhoto()
        {

        }
    }
}