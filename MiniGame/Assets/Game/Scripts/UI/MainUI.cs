// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForState.ForUI;
using InGame.ForState;

namespace InGame.ForUI
{
    public class MainUI : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("State UI")]
        [SerializeField] private ReadyView  _readyView  = null;
        [SerializeField] private PlayView   _playView   = null;
        [SerializeField] private ResultView _resultView = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------

        // --------------------------------------------------
        // Fucntions - Nomal
        // --------------------------------------------------
        public StateView GetStateUI()
        {
            var currentState = StateMachine.Instance.CurrentState;
            switch (currentState)
            {
                case EState.Ready:  return _readyView;
                case EState.Play:   return _playView;
                case EState.Result: return _resultView;
                default:            return null;
            }
        }

    }
}