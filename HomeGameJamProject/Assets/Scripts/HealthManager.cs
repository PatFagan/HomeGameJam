using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float health;
    float maxHealth;
    public string damageTag;

    void Start()
    {
        // set maxHealth to default health amount
        maxHealth = health;
    }

    void Update()
    {
        // update health bar visual
        healthBar.fillAmount = health/maxHealth;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == damageTag)
        {
            print(gameObject.name);
            
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
