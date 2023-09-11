using System;
using System.Collections;
using UnityEngine;

public abstract class MiniControlBase : MonoBehaviour
{
    // --------------------------------------------------
    // Mini Game State Enum
    // --------------------------------------------------
    protected enum EState 
    { 
        Unknown = 0,
        Init    = 1,
        Intro   = 2,
        Play    = 3,
        Success = 4,
        Fail    = 5,
        Finish  = 6,
    }

    // --------------------------------------------------
    // Components
    // --------------------------------------------------
    //[SerializeField] private 

    // --------------------------------------------------
    // Variables
    // --------------------------------------------------
    private Coroutine _co_StateOwner = null;
    private EState    _gameState     = EState.Unknown;

    // --------------------------------------------------
    // Functions - Nomal
    // --------------------------------------------------
    protected void ChangeState(EState gameState, Action doneCallBack)
    {
        if (!Enum.IsDefined(typeof(EState), _gameState))
        {
            Debug.LogError($"[MiniControlBase.ChangeState] {Enum.GetName(typeof(EState), gameState)}은 정의되어있지 않은 Enum 값입니다.");
            return;
        }

        if (_gameState == gameState)
            return;

        _gameState = gameState;

        if (_co_StateOwner != null)
            StopCoroutine(_co_StateOwner);

        switch (_gameState)
        {
            case EState.Init:    _Co_Init();    break;
            case EState.Intro:   _Co_Intro();   break;
            case EState.Play:    _Co_Play();    break;
            case EState.Success: _Co_Success(); break;
            case EState.Fail:    _Co_Fail();    break;
            case EState.Finish:  _Co_Finish();  break;
        }
    }

    // --------------------------------------------------
    // Functions - Coroutine
    // --------------------------------------------------
    protected IEnumerator _Co_Init(Action doneCallBack)
    {
        yield return null;
    }

    protected IEnumerator _Co_Intro(Action doneCallBack)
    {
        yield return null;
    }

    protected IEnumerator _Co_Play(Action doneCallBack)
    {
        yield return null;
    }

    protected IEnumerator _Co_Success(Action doneCallBack)
    {
        yield return null;
    }

    protected IEnumerator _Co_Fail(Action doneCallBack)
    {
        yield return null;
    }

    protected IEnumerator _Co_Finish(Action doneCallBack)
    {
        yield return null;
    }
}