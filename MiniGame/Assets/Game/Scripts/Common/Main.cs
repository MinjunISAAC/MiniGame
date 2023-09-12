// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utiltiy.ForLoader;
using InGame.ForCamera;
using InGame.ForMap;
using InGame.ForState;
using InGame.ForUI;
using InGame.ForState.ForUI;
using InGame.ForMiniGame;

namespace InGame
{
    public class Main : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Manage Group")]
        [SerializeField] private CamController   _camController   = null;
        [SerializeField] private MapManager      _mapManager      = null;
        [SerializeField] private MiniGameManager _miniGameManager = null;

        [Header("UI Group")]
        [SerializeField] private MainUI          _mainUI          = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public static Main NullableInstance
        {
            get;
            private set;
        } = null;

        public CamController   CamController   => _camController;
        public MapManager      MapManager      => _mapManager;
        public MiniGameManager MiniGameManager => _miniGameManager; 
        
        public MainUI          MainUI          => _mainUI;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void Awake() { NullableInstance = this; }

        private IEnumerator Start()
        {
            StateMachine.Instance.ChangeState(EState.Ready, null);

            var readyView = (ReadyView)_mainUI.GetStateUI();
            readyView.SetToMiniGameUnit
            (
                (miniGameType) =>
                {
                    readyView.gameObject.SetActive(false);
                    Loader.Instance.Visiable
                    (
                        3f, 
                        () => 
                        {
                            _camController  .ActivedToMainCam(false);
                            _mapManager     .VisiableToMainMap(false);
                            _miniGameManager.CreatedToMiniGame(miniGameType);
                        },
                        () => 
                        {
                            _miniGameManager.PlayToMiniGame();
                        }
                    ); 
                }
            );

            yield return null;
        }
    }
}