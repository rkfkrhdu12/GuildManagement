using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eGameStateType
{
    Start,
    Load,
    Progress,
    End,
    Pause,
    Last,
}

public class GameManager
{
    public eGameStateType CurGameState = eGameStateType.Start;
    public List<string> CharacterNameList;

    private int LoadCount = 0;

    public void OnRegisterLoad()
    {
        ++LoadCount;
    }

    public void OnLoadComplete()
    {
        --LoadCount;
        if (LoadCount <= 0) OnProgress();
    }

    void OnProgress()
    {
        CurGameState = eGameStateType.Progress;

    }

    #region Singleton

    static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();
            return instance;
        }
    } 
    #endregion
}

public class LogManager
{
    static public void Log(string msg)
    {
#if UNITY_EDITOR
        Debug.Log(msg);
#endif
    }
}