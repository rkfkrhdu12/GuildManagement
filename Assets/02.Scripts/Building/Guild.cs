using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Guild : MonoBehaviour
{
    GameManagerData _gameManager;
    InGameController _inGameController;

    List<AIController> _memberList = new List<AIController>();
    int _gold = 0;

    float _spawnTime = 0.0f;

    public void AddMember(AIController member)
    {
        if (_memberList.Contains(member)) return;
        _memberList.Add(member);

        member.CurCharacter = member.gameObject.AddComponent<Character>();
        _inGameController.SpawnCharacter(member.CurCharacter);

        Debug.Log($"AI :  I'm {member.CurCharacter.MyClass} !!!");
    }

    public void RemoveMember(AIController member)
    {
        if (!_memberList.Contains(member)) return;
        _memberList.Remove(member);
    }

    void Initialized()
    {
        if (_gameManager == null) return;
        if (_gameManager.InGame == null) return;

        _inGameController = _gameManager.InGame;
        _inGameController.Guild = this;
    }

    private void Awake()
    {
        _gameManager = GameManagerData.Instance;
        _gameManager.OnSubSystemInit += Initialized;
    }

    private void FixedUpdate()
    {
        if (_gameManager.GameState != eGameStateType.Progress) return;

        _spawnTime += Time.fixedDeltaTime;
        float Interval = SpawnInterval;
        if (Interval <= _spawnTime)
        {
            _spawnTime = 0.0f;

            Debug.Log("Guild : Spawn !!!");
            _inGameController.OnSpawn();
        }

        _gameManager.RemainSpawnTime = Interval - _spawnTime;
    }

    float SpawnInterval
    {
        get { if (_gameManager == null) return 300.0f; return _gameManager.SpawnInterval; }
    }
}
