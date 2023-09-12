using InGame.ForMiniGame;
using InGame.ForMiniGame.ForUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utiltiy.ForLoader;

public class Test : MonoBehaviour
{
    [SerializeField] private HotDog_MiniGame _miniGame = null;

    void Start()
    {
        _miniGame.ChangeState(MiniGameBase.EState.Init, null);
    }
}
