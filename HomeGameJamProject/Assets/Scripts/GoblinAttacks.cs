using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttacks : MonoBehaviour
{
    // movement variables
    public float moveSpeed;

    // raycast start variables
    public float width;

    // attack variables
    public GameObject meleeAttack;
    public float attackDistance;
    public float timeBetweenAttacks;

    bool attacking = false;
    bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attacking());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AttackCheck();

        if (moving && !attacking)
        {
            Movement();
        }
    }

    void Movement()
    {
        transform.position += new Vector3(moveSpeed, 0f, 0f);
    }

    IEnumerator Attacking()
    {
        if (attacking)
        {
            Instantiate(meleeAttack, transform.position, Quaternion.identity); 
        }

        yield return new WaitForSeconds(timeBetweenAttacks);
        StartCoroutine(Attacking());
    }

    void AttackCheck()
    {
        int layerMask = 1 << 8;

        Vector3 rayCastStart = new Vector3(transform.position.x - width, transform.position.y, 0f);
        bool nearEnemy = Physics2D.Raycast(rayCastStart, Vector3.left, attackDistance + .75f, layerMask);
        // buffer between units
        bool buffer = Physics2D.Raycast(rayCastStart, Vector3.left, 1f);
        
        if (buffer)
        {
            moving = false;
        }

        if (nearEnemy || buffer)
        {
            attacking = true;
        }
        else if (!nearEnemy)
        {
            moving = true;
            attacking = false;
        }
    }
}