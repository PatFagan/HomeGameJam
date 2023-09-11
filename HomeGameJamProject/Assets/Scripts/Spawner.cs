using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnedObjects;
    float spawnDelay = 3;

    int tick = 0;
    int maxEnemySpawn = 1;

    void Start()
    {
        StartCoroutine(Spawning());
    }

    void IncreaseDifficulty()
    {
        switch(tick) 
        {
        case 10:
            maxEnemySpawn = 3;
            break;
        case 15:
            spawnDelay = 2.5f;
            break;
        case 20:
            maxEnemySpawn = 5;
            break;
        case 25:
            spawnDelay = 2;
            break;
        case 30:
            spawnDelay = 1.5f;
            break;
        case 35:
            maxEnemySpawn = spawnedObjects.Length;
            break;
        default:
            // code block
            break;
        }
    }

    IEnumerator Spawning()
    {
        int index = Random.Range(0, maxEnemySpawn);
        print(maxEnemySpawn);
        GameObject enemy = Instantiate(spawnedObjects[index], transform.position, transform.rotation);
        yield return new WaitForSeconds(spawnDelay);

        tick++;
        IncreaseDifficulty();

        StartCoroutine(Spawning());
    }
}