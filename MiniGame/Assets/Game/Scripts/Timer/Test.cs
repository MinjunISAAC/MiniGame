using InGame.ForMiniGame;
using InGame.ForMiniGame.ForUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utiltiy.ForLoader;

public class Test : MonoBehaviour
{
    [SerializeField] private Maze_MiniGame _mazeMiniGame = null;

    void Start()
    {
        _mazeMiniGame.ChangeState(MiniGameBase.EState.Init, null);
    }
}
