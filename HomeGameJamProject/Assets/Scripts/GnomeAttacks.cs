using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeAttacks : MonoBehaviour
{
    // movement variables
    public float moveSpeed;
    float negMoveSpeed;

    // raycast start variables
    public float width;

    // attack variables
    public GameObject meleeAttack;
    public float attackDistance;
    public float timeBetweenAttacks;
    public float attackScalar = 1f;

    bool attacking = false;
    bool moving = true;
    public bool constantlyMoveAndAttack;

    // Start is called before the first frame update
    void Start()
    {   
        negMoveSpeed = -moveSpeed/3;

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

        if (constantlyMoveAndAttack)
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
        if (attacking || constantlyMoveAndAttack)
        {
            GameObject newAttack = meleeAttack;

            Instantiate(newAttack, transform.position, Quaternion.identity); 
        }

        yield return new WaitForSeconds(timeBetweenAttacks);
        StartCoroutine(Attacking());
    }

    void AttackCheck()
    {
        int layerMask = 1 << 7;
        
        Vector3 rayCastStart = new Vector3(transform.position.x + width, transform.position.y, 0f);
        bool nearEnemy = Physics2D.Raycast(rayCastStart, Vector3.right, attackDistance + .75f, layerMask);
        // buffer between units
        bool buffer = Physics2D.Raycast(rayCastStart, Vector3.right, 1f);

        bool noEnemy = Physics2D.Raycast(rayCastStart, Vector3.right, 200f, layerMask);
        
        if (!noEnemy)
        {
            moveSpeed = negMoveSpeed;
        }
        else if (noEnemy)
        {
            moveSpeed = Mathf.Abs(moveSpeed);
        }

        if (buffer)
        {
            moving = false;
        }

        if (nearEnemy)
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