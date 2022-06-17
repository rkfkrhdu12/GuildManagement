using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Status
{
    float Health;
    float AttackDamage;
    float AttackSpeed;
    float DefenceValue;
    float MoveSpeed;
    float CriticalPercent;
    float CriticalDamage;
}

public class Character : MonoBehaviour
{
    eClassType _myClass;
    string _name;
    AIController _curController;
    Status _status;
    public void OnSpawn(AIController aiController)
    {
        Debug.Log("Character :  I'm Spawn !!!");
        _curController = aiController;

        gameObject.SetActive(true);
    }

    public void OnDead()
    {
        gameObject.SetActive(false);
        Destroy(this);
    }

    public eClassType MyClass
    {
        get { return _myClass; }
        set { _myClass = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public Status Status
    {
        get { return _status; }
        set { _status = value; }
    }
}
