// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.SimpleFSM;

namespace InGame.ForState
{
    public class State_Ready : SimpleState<EState>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Owner

        // ----- UI

        // ----- Manage

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public override EState State => EState.Ready;

        protected override void _Start(EState preStateKey, object startParam)
        {
            Debug.Log($"<color=yellow>[State_{State}._Start] {State} State에 진입하였습니다.</color>");

            #region <Manage Group>
            
            #endregion
        }

        protected override void _Finish(EState nextStateKey)
        {
            Debug.Log($"<color=yellow>[State_{State}._Start] {State} State에에 이탈하였습니다.</color>");
        }
    }
}