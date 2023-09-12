// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

namespace InGame.ForCamera
{
    public class CamController : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Camera Group")]
        [SerializeField] private Camera _mainCamera = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void ActivedToMainCam(bool active)
        {
            _mainCamera.gameObject.SetActive(active);
        }
    }
}