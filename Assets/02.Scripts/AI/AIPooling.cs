using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPooling : MonoBehaviour
{
    public GameObject AIPoolingPrefab;

    private List<AIController> _poolingList = new List<AIController>();
    int _curEnableIndex = 0;
    int _remainDeadAICount = 0;

    GameManagerData _gameManager;
    Transform _transform;

    public void Spawn()
    {
        Debug.Log("AIPool :  OK !!!");
        AIController spawnCharacter = _poolingList[_curEnableIndex];
        spawnCharacter.CurState = eAIState.Idle;
        spawnCharacter.ReSpawn();

        ListCheck();
    }

    void ListCheck()
    {
        _curEnableIndex = -1;
        _remainDeadAICount = 0;

        int indexCount = 0;
        foreach (var i in _poolingList)
        {
            if (i != null)
            {
                if (i.CurState == eAIState.Dead)
                {
                    if (_curEnableIndex == -1)
                    {
                        _curEnableIndex = indexCount;
                    }
                    ++_remainDeadAICount;
                }
            }
            ++indexCount;
        }
    }

    private void Initialized()
    {
        if (_gameManager == null) return;
        if (_gameManager.InGame == null) return;

        _gameManager.InGame.AIPool = this;

        _gameManager.InGame.OnSpawn += Spawn;
    }

    private void Awake()
    {
        _transform = gameObject.transform;
        if (_poolingList == null)
            _poolingList = new List<AIController>();

        _gameManager = GameManagerData.Instance;
        _gameManager.OnSubSystemInit += Initialized;

        StartCoroutine(ManagementRoutine());
    }
    private void Start()
    {
        for (int i = 0; i < 2; ++i)
        {
            GameObject cloneAI = Instantiate(AIPoolingPrefab, null);

            AIController controller = cloneAI.GetComponent<AIController>();
            if (controller != null)
                _poolingList.Add(controller);
        }
    }

    WaitForSeconds _addCoolDownTime = new WaitForSeconds(1.0f);
    WaitForSeconds _waitTime = new WaitForSeconds(10.0f);
    IEnumerator ManagementRoutine()
    {
        while (gameObject.activeSelf)
        {
            if (_remainDeadAICount <= 2 || _curEnableIndex == -1)
            {
                GameObject cloneAI = Instantiate(AIPoolingPrefab, null);

                AIController controller = cloneAI.GetComponent<AIController>();
                if (controller != null)
                    _poolingList.Add(controller);

                ListCheck();

                yield return _addCoolDownTime;
            }
            else
            {
                ListCheck();

                yield return _waitTime;
            }

        }
    }

}
