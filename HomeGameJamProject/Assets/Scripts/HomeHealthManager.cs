using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeHealthManager : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float maxHealth;
    public string damageTag;

    bool dead = false;

    public GameObject evictionMenu;

    void Start()
    {
        // set maxHealth to default health amount
        maxHealth = health*2f;
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
            health--;

            // destroy attack projectile
            Destroy(collider.gameObject);

            if (health <= 0)
            {
                if (!dead)
                {
                    // open fail menu
                    evictionMenu.SetActive(true);
                }
                dead = true;
            }
        }
    }
}
