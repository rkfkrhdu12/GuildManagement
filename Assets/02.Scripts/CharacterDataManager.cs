using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text.RegularExpressions;

public enum eClassType
{
    Unknown,
    Berserker,
    Paladin,
    Elementalist,
    Wizard,
    Archer,
    Thief,
    Priest,
    Last,
}

public class CharacterDataManager : MonoBehaviour
{
    GameManagerData _gameManager;

    [SerializeField] string CharacterListFileName;

    private void Awake()
    {
        _gameManager = GameManagerData.Instance;
        _gameManager.RegisterLoad();

        InitCharacterList();

        _gameManager.CompleteLoad();
    }

    void InitCharacterList()
    {
        if (CharacterListFileName == "") return;

        TextAsset data = Resources.Load(CharacterListFileName) as TextAsset;

        var lines = Regex.Split(data.text, "\r\n");

        for (int i = 2; i < lines.Length; ++i)
        {
            var strings = Regex.Split(lines[i], "\t");

            if (strings.Length <= 0 || strings[0] == "") continue;
            _gameManager.CharacterNameList.Add(strings[1]);
        }
    }
}
