using InGame.ForMiniGame;
using InGame.ForMiniGame.ForUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utiltiy.ForLoader;

public class Test : MonoBehaviour
{
    [SerializeField] private Maze_MiniGame   _miniGame_0 = null;
    [SerializeField] private HotDog_MiniGame _miniGame_1 = null;

    void Start()
    {
        _miniGame_1.ChangeState(MiniGameBase.EState.Init, null);
    }
}
