using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttacks : MonoBehaviour
{
    // movement variables
    public float moveSpeed;

    // attack variables
    public GameObject meleeAttack;
    public float attackDistance;

    bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attacking());
    }

    // Update is called once per frame
    void Update()
    {
        AttackCheck();

        if (!attacking)
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

        yield return new WaitForSeconds(1f);
        StartCoroutine(Attacking());
    }

    void AttackCheck()
    {
        Vector3 rayCastStart = new Vector3(transform.position.x - .5f, transform.position.y, 0f);
        bool nearEnemy = Physics2D.Raycast(rayCastStart, Vector3.left, attackDistance + .75f);
        
        if (nearEnemy)
        {
            attacking = true;
        }
        else if (!nearEnemy)
        {
            attacking = false;
        }
    }
}