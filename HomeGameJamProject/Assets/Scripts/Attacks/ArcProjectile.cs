using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcProjectile : MonoBehaviour
{
    public float xSpeed, ySpeed, lifetime;
    float floatTimer = 2f;

    public string targetTag;
    float currentDist, midDist;

    GameObject enemy;
    float savedEnemyX;

    void Start()
    {
        Destroy(gameObject, lifetime);

        enemy = GameObject.FindGameObjectWithTag(targetTag);
        savedEnemyX = enemy.transform.position.x;

        currentDist = Mathf.Abs(transform.position.x - enemy.transform.position.x);
        midDist = currentDist / 2;
    }

    void FixedUpdate()
    {
        if (enemy)
        {
            currentDist = Mathf.Abs(transform.position.x - savedEnemyX);
        }

        floatTimer -= Time.deltaTime;

        if (currentDist > midDist)
            transform.Translate(new Vector3(xSpeed, currentDist*ySpeed, 0f));
        else if (currentDist <= midDist)
            transform.Translate(new Vector3(xSpeed, currentDist*-ySpeed, 0f));
    }
}