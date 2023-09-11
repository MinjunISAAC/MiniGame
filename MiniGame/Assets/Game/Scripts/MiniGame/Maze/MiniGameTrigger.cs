using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.ForMiniGame.ForControl.ForMaze
{
    public enum ETriggerType
    {
        Unknown = 0,
        Start   = 1,
        Wall    = 2,
        End     = 3,
    }

    public class MiniGameTrigger : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private ETriggerType _triggerState = ETriggerType.Unknown;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private SphereCollider _collider = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public ETriggerType TriggerState => _triggerState;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void OnTriggerEnter(Collider other)
        {

        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit(float radius, bool isTrigger)
        {
            var col = gameObject.AddComponent<SphereCollider>();

            _collider           = col;
            _collider.radius    = radius;
            _collider.isTrigger = isTrigger;    
        }
    }
}