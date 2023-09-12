// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.SimpleFSM;
using InGame.ForState.ForUI;

namespace InGame.ForState
{
    public class State_Ready : SimpleState<EState>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Owner
        private Main      _owner     = null;

        // ----- UI
        private ReadyView _readyView = null;

        // ----- Manage

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public override EState State => EState.Ready;

        // --------------------------------------------------
        // Functions - Nomal(Override)
        // --------------------------------------------------
        protected override void _Start(EState preStateKey, object startParam)
        {
            Debug.Log($"<color=yellow>[State_{State}._Start] {State} State�� �����Ͽ����ϴ�.</color>");

            #region <Manage Group>
            _owner = Main.NullableInstance;
            if (_owner == null)
            {
                Debug.LogError($"[State_{State}._Start] Main�� Null �����Դϴ�.");
                return;
            }

            _readyView = (ReadyView)_owner.MainUI.GetStateUI();
            if (_readyView == null)
            {
                Debug.LogError($"[State_{State}._Start] {State} View�� Null �����Դϴ�.");
                return;
            }
            #endregion

        }

        protected override void _Finish(EState nextStateKey)
        {
            Debug.Log($"<color=yellow>[State_{State}._Start] {State} State���� ��Ż�Ͽ����ϴ�.</color>");
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
    }
}