using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void FOnSpawn();

public class Guild : MonoBehaviour
{
    Guild()
    {
        OnSpawn += Spawn;
    }
    double SpawnInterval = 5.0;
    double SpawnTime = 300.0;

    public FOnSpawn OnSpawn;

    void Spawn()
    {
        Debug.Log("Spawn !");
    }

    private void Awake()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (gameObject.activeSelf)
        {
            SpawnTime += Time.deltaTime;
            if(SpawnInterval <= SpawnTime)
            {
                SpawnTime = 0.0;
                OnSpawn();
            }

            yield return null;
        }
    }
}
