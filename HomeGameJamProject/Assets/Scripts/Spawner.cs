using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnedObjects;
    public float spawnDelay;

    void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        int index = Random.Range(0, spawnedObjects.Length);
        GameObject enemy = Instantiate(spawnedObjects[index], transform.position, transform.rotation);
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(Spawning());
    }
}