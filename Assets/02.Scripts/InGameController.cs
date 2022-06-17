using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void FOnSpawn();

public class InGameController : MonoBehaviour
{
    GameManagerData _gameManager;

    public FOnSpawn OnSpawn;

    private AIPooling _aiPool = null;
    public AIPooling AIPool
    {
        get { return _aiPool; }
        set { if (_aiPool == null) _aiPool = value; }
    }

    private Guild guild;
    public Guild Guild
    {
        get { return guild; }
        set { if (guild == null) guild = value; }
    }

    public void SpawnCharacter(Character character)
    {
        character.Name = _gameManager.CharacterNameList[Random.Range(0, _gameManager.CharacterNameList.Count)];
        _gameManager.CharacterNameList.Remove(character.Name);
        if (_gameManager.CharacterNameList.Count == 0)
            _gameManager.CharacterNameList = _gameManager.DefaultCharacterNameList;

        Debug.Log($"Character :  I'm {character.Name} !!!");
    }

    void Initialized()
    {
        if (_gameManager == null) return;
        _gameManager.InGame = this;
    }

    private void Awake()
    {
        _gameManager = GameManagerData.Instance;
        _gameManager.OnMainSystemInit += Initialized;
    }
}
