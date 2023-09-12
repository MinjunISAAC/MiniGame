// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

namespace InGame.ForMap
{
    public class MapManager : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private GameObject _mainMap = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void VisiableToMainMap(bool visiable)
        {
            if (_mainMap == null)
            {
                Debug.LogError($"<color=red>[MapManager.VisiableToMainMap] Main Map�� �������� �ʽ��ϴ�.</color>");
                return;
            }

            _mainMap.SetActive(visiable);
        }
    }
}