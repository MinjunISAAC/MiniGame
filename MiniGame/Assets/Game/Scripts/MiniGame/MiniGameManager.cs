// ----- C#
using InGame.ForMiniGame.ForData;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

namespace InGame.ForMiniGame
{
    public class MiniGameManager : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private List<MiniGameData> _dataInfos       = null;
        [SerializeField] private Transform          _miniGameParents = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private MiniGameBase _currentMiniGame = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Public
        public void CreatedToMiniGame(EMiniGameType miniGameType)
        {
            var miniGameOrigin = _GetToMiniGame(miniGameType);
            _currentMiniGame = Instantiate(miniGameOrigin, _miniGameParents);
        }

        public void PlayToMiniGame()
        {
            if (_currentMiniGame == null)
            {
                Debug.LogError($"<color=red>[MiniGameManager.PlayMiniGame] 미니 게임이 준비되지 않았습니다.</color>");
                return;
            }
            _currentMiniGame.ChangeState(MiniGameBase.EState.Init, null);
        }

        public void ClearToMiniGame()
        {
            if (_currentMiniGame == null)
                return;

            Destroy(_currentMiniGame.gameObject);
            _currentMiniGame = null;
        }

        // ----- Private
        private MiniGameBase _GetToMiniGame(EMiniGameType miniGameType)
        {
            MiniGameBase miniGame = null;

            for (int i = 0; i < _dataInfos.Count; i++)
            {
                var dataInfo = _dataInfos[i];

                if (dataInfo.MiniGameType == miniGameType)
                {
                    miniGame = dataInfo.MiniGame;
                    break;
                }
            }

            if (miniGame == null) return null;
            else                  return miniGame;
        }
    }
}