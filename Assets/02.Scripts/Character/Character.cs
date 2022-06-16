using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum eCharacterGradeType
{
    Normal,
    Rare,
    Epic,
    Legendary,
    Last
}

public enum eCharacterClassType
{
    Unknown,
    Berserker,
    Paladin,
    Elementalist,
    Wizzard,
    Archer,
    Thief,
    Priest,
    Last
}

public struct Status
{
    float Health;
    float AttackDamage;
    float DefenceDamage;
    float AttackSpeed;
    float CriticalPercent;
}

public class Character : MonoBehaviour
{
    protected int _code;
    protected eCharacterGradeType _gradeType = eCharacterGradeType.Normal;
    protected eCharacterClassType _classType;

    protected Status _status;

    public Character() 
    {
        _classType = eCharacterClassType.Unknown;
    }

    public Character(int code, string Name, eCharacterGradeType gradeType)
    {
        _code = code;
        name = Name;
        _gradeType = gradeType;
    }

    protected virtual void Awake()
    {
        Debug.Log($"I'm {ClassType} !");
    }

    public int Code { get { return _code; } }
    public eCharacterClassType ClassType { get { return _classType; } }
    public eCharacterGradeType GradeType { get { return _gradeType; } }
}
