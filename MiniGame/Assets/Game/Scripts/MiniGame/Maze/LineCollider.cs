// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForMiniGame.ForControl.ForMaze;

namespace InGame.ForMiniGame.ForControl
{
    public class LineCollider : MonoBehaviour
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private SphereCollider _collider  = null;
        private Rigidbody      _rigidBody = null;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent<MiniGameTrigger>(out var trigger);

            switch (trigger.TriggerType)
            {
                case ETriggerType.Start : ColliderEvent.OnStartAction();  break;
                case ETriggerType.Wall  : ColliderEvent.OnFailAction();   break;
                case ETriggerType.End   : ColliderEvent.OnFinishAction(); break;
            }
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit(float radius, bool isTrigger)
        {
            var col    = gameObject.AddComponent<SphereCollider>();
            _rigidBody = gameObject.AddComponent<Rigidbody>();

            _rigidBody.useGravity  = false;
            _rigidBody.isKinematic = true;

            _collider           = col;
            _collider.radius    = radius;
            _collider.isTrigger = isTrigger;
        }
    }
}