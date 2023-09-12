// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.SimpleFSM;
using InGame.ForState.ForUI;
using InGame.ForMiniGame;
using InGame.ForCamera;
using InGame.ForMap;

namespace InGame.ForState
{
    public class State_Ready : SimpleState<EState>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Owner
        private Main            _owner           = null;

        // ----- UI 
        private ReadyView       _readyView       = null;

        // ----- Manage
        private MiniGameManager _miniGameManager = null;
        private CamController   _camController   = null;
        private MapManager      _mapManager      = null;

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

            _miniGameManager = _owner.MiniGameManager;
            if (_miniGameManager == null)
            {
                Debug.LogError($"[State_{State}._Start] Mini Game Manager�� Null �����Դϴ�.");
                return;
            }

            _camController = _owner.CamController;
            if (_camController == null)
            {
                Debug.LogError($"[State_{State}._Start] Cam Controller�� Null �����Դϴ�.");
                return;
            }

            _mapManager = _owner.MapManager;
            if (_mapManager == null)
            {
                Debug.LogError($"[State_{State}._Start] Map Manager�� Null �����Դϴ�.");
                return;
            }

            _readyView = (ReadyView)_owner.MainUI.GetStateUI();
            if (_readyView == null)
            {
                Debug.LogError($"[State_{State}._Start] {State} View�� Null �����Դϴ�.");
                return;
            }
            #endregion

            // Mini Game �ʱ�ȭ
            _miniGameManager.ClearToMiniGame();

            // Camera �ʱ�ȭ
            _camController.ActivedToMainCam(true);

            // Map Ȱ��ȭ
            _mapManager.VisiableToMainMap(true);

            // UI Ȱ��ȭ
            _readyView.gameObject.SetActive(true);
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