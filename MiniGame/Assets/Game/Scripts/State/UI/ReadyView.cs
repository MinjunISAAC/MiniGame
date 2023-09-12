// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

// ----- User Defined
using InGame.ForMiniGame.ForUI;
using InGame.ForMiniGame;

namespace InGame.ForState.ForUI
{
    public class ReadyView : StateView
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private List<MiniGameUnit> _miniGameUnitList = null;
        [SerializeField] private Button             _BTN_Gallery      = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public override void OnInit()   { }
        public override void OnFinish() { }

        public void SetToMiniGameUnit(Action<EMiniGameType> onClickBtnEvent)
        {
            for (int i = 0; i < _miniGameUnitList.Count; i++) 
            { 
                var unit     = _miniGameUnitList[i];
                unit.SetOnClickEvent(onClickBtnEvent);
            }
        }
    }
}