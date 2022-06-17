using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class SpawnTimeUI : MonoBehaviour
{
    GameManagerData _gameManager;
    TMP_Text _text;
    private void Awake()
    {
        _gameManager = GameManagerData.Instance;
        _text = GetComponent<TMP_Text>();
    }

    public void LateUpdate()
    {
        if (_text == null) return;

        _text.text = ((int)_gameManager.RemainSpawnTime).ToString();
    }
}
