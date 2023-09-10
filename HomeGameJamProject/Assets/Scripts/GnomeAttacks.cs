using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeAttacks : MonoBehaviour
{
    // movement variables
    public float moveSpeed;

    // attack variables
    public GameObject meleeAttack;
    public float attackDistance;

    bool attacking = false;
    public bool constantlyMoveAndAttack;

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
            Instantiate(meleeAttack, transform.position, Quaternion.identity); 
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(Attacking());
    }

    void AttackCheck()
    {
        int layerMask = 1 << 7;
        
        Vector3 rayCastStart = new Vector3(transform.position.x + .5f, transform.position.y, 0f);
        bool nearEnemy = Physics2D.Raycast(rayCastStart, Vector3.right, attackDistance + .75f, layerMask);
        // buffer between units
        bool buffer = Physics2D.Raycast(rayCastStart, Vector3.right, 1f);

        if (nearEnemy || buffer)
        {
            attacking = true;
        }
        else if (!nearEnemy)
        {
            attacking = false;
        }
    }
}