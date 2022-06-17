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

public delegate void FOnInitialized();

[System.Serializable]
public class GameManagerData
{
    [HideInInspector]
    public GameManager gameManager;
    public eGameStateType GameState = eGameStateType.Start;

    InGameController inGame = null;

    public float SpawnInterval
    {
        get
        {
            if (gameManager == null) return 300.0f;
            return gameManager.SpawnInterval;
        }
    }
    public float RemainSpawnTime = 300.0f;

    public List<string> DefaultCharacterNameList = new List<string>();
    public List<string> CharacterNameList = new List<string>();

    private int _loadCount = 0;

    public void RegisterLoad() { ++_loadCount; }

    public void CompleteLoad() { --_loadCount; OnProgress(); }

    void OnProgress()
    {
        if (_loadCount > 0) return;

        GameState = eGameStateType.Progress;
        OnCompleteLoad();

        foreach (var i in CharacterNameList)
            DefaultCharacterNameList.Add(i);
    }

    public FOnInitialized OnMainSystemInit;
    public FOnInitialized OnSubSystemInit;
    public FOnInitialized OnMainObjectInit;
    public FOnInitialized OnSubObjectInit;

    public FOnInitialized OnCompleteLoad;

    public InGameController InGame
    {
        get { return inGame; }
        set { if (inGame == null) inGame = value; }
    }

    static GameManagerData instance = null;
    public static GameManagerData Instance
    {
        get
        {
            if (instance == null) instance = new GameManagerData();

            return instance;
        }
    }
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameManagerData data;

    [SerializeField]
    public float SpawnInterval = 30.0f;

    void LoadEnd()
    {
        Time.timeScale = 1.0f;
    }

    private void Awake()
    {
        data = GameManagerData.Instance;
        if (data.gameManager == null)
            data.gameManager = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // Time.timeScale = 0.0f;

        for (int i = 0; i < 4; ++i)
            data.RegisterLoad();
        OnMainSystemInit += data.CompleteLoad;
        OnSubSystemInit += data.CompleteLoad;
        OnMainObjectInit += data.CompleteLoad;
        OnSubObjectInit += data.CompleteLoad;

        data.OnCompleteLoad += LoadEnd;
    }

    private void Start()
    {
        if (OnMainSystemInit != null)
        {
            OnMainSystemInit();
        }
        if (OnSubSystemInit != null)
        {
            OnSubSystemInit();
        }

        if (OnMainObjectInit != null)
        {
            data.OnMainObjectInit();
        }
        if (OnSubObjectInit != null)
        {
            OnSubObjectInit();
        }
    }

    public FOnInitialized OnMainSystemInit
    {
        get { return data.OnMainSystemInit; }
        set { data.OnMainSystemInit = value; }
    }
    public FOnInitialized OnSubSystemInit
    {
        get { return data.OnSubSystemInit; }
        set { data.OnSubSystemInit = value; }
    }
    public FOnInitialized OnMainObjectInit
    {
        get { return data.OnMainObjectInit; }
        set { data.OnMainObjectInit = value; }
    }
    public FOnInitialized OnSubObjectInit
    {
        get { return data.OnSubObjectInit; }
        set { data.OnSubObjectInit = value; }
    }
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