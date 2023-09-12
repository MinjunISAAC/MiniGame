// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

namespace InGame.ForMiniGame.ForControl
{
    public abstract class MiniGameControlBase : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Camera Group")]
        [SerializeField] protected Camera _camera = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        protected MiniGameBase.EState _currentState = MiniGameBase.EState.Unknown;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void Update()
        {
            switch (_currentState)
            {
                case MiniGameBase.EState.Intro  : UpdateToIntro();   break;
                case MiniGameBase.EState.Play   : UpdateToPlay();    break;
                case MiniGameBase.EState.Finish : UpdateToSuccess(); break;
                case MiniGameBase.EState.Fail   : UpdateToFail();    break;
            }
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void SetToCamera(Camera cam)
        {
            if (_camera == null)
            {
                _camera = cam;
                return;
            }
        }

        public void ChangeToCurrentState(MiniGameBase.EState state)
        {
            if (_currentState == state)
                return;

            _currentState = state;
        }

        protected virtual void UpdateToIntro()   { }
        protected virtual void UpdateToPlay()    { }
        protected virtual void UpdateToSuccess() { }
        protected virtual void UpdateToFail()    { }
    }
}