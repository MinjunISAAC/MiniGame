// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForCamera;
using InGame.ForMap;

namespace InGame
{
    public class Main : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Manage Group")]
        [SerializeField] private CamController _camController = null;
        [SerializeField] private MapManager    _mapManager    = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public static Main NullableInstance
        {
            get;
            private set;
        } = null;

        public CamController CamController => _camController;
        public MapManager    MapManager    => _mapManager;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void Awake() { NullableInstance = this; }

        private IEnumerator Start()
        {
            
            yield return null;
        }
    }
}