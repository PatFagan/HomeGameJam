using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float health;
    public string damageTag;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == damageTag)
        {
            health--;

            // destroy attack projectile
            Destroy(collider.gameObject);

            if (health <= 0)
            {
                // add some death effect here
                Destroy(gameObject);
            }
        }
    }
}
