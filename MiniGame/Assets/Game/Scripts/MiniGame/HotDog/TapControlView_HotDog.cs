// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

// ----- Unity
using UnityEngine;

// ----- User Defined

namespace InGame.ForMiniGame.ForUI
{
    public class TapControlView_HotDog : TapControlView
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------

        [SerializeField] private TextMeshProUGUI _TMP_Count = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void RefreshToCount(int count) => _TMP_Count.text = $"{count}"; 
    }
}