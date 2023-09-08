using InGame.ForState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    public class Main : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public static Main NullableInstance
        {
            get;
            private set;
        } = null;

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