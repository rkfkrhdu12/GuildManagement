using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum eAIState
{
    Dead,
    Idle,
    Combat,
    Heal,
    Last,
}

public class AIController : MonoBehaviour
{
    eAIState _curState = eAIState.Dead;

    Character _character = null;
    NavMeshAgent _agent = null;

    Guild _guild = null;

    Transform _transform;

    public void ReSpawn()
    {
        Debug.Log("AIController :  I'm Ready !!!");

        if (_guild == null)
            _guild = GameManagerData.Instance.InGame.Guild;
        if (_guild != null)
            _guild.AddMember(this);

        CurCharacter.OnSpawn(this);

        float forward = Random.Range(-1.0f, 1.0f);
        float right = Random.Range(-1.0f, 1.0f);

        Vector3 position = new Vector3(right, 0.0f, forward);
        position.Normalize();

        if (_agent != null)
            _agent.SetDestination(position * 4);
    }

    void Dead()
    {
        _guild.RemoveMember(this);

        if (CurCharacter != null)
        {
            CurCharacter.OnDead();

            CurCharacter = null;
        }

        CurState = eAIState.Dead;
    }

    private void Awake()
    {
        CurState = eAIState.Dead;

        _agent = GetComponent<NavMeshAgent>();

        _agent.updateRotation = false;
        _transform = transform;
    }

    private void FixedUpdate()
    {
        if (_agent == null) return;

        Vector3 destination = _agent.destination;
        if(destination == Vector3.zero) return;

        Quaternion lookatRotation = Quaternion.LookRotation(_transform.position, destination);
        Quaternion rotation = _transform.rotation;

        Quaternion resultRotation = Quaternion.Lerp(rotation, lookatRotation, Time.fixedDeltaTime);
        
        _transform.rotation = new Quaternion(rotation.x, resultRotation.y, rotation.z, rotation.w);
    }

    public eAIState CurState
    {
        get { return _curState; }
        set { _curState = value; }
    }
    public Character CurCharacter
    {
        get { return _character; }
        set { _character = value; }
    }
}
