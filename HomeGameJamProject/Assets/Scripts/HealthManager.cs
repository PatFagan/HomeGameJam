using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float health;
    float maxHealth;
    public string damageTag;

    public int coinsGranted;
    bool dead = false;

    public Material flashMat;
    Material defaultMat;

    public GameObject hitNumber;

    public AudioSource death;

    int damageOverTimeTicks = 10;

    public ParticleSystem deathParticle;
    void Start()
    {
        // set maxHealth to default health amount
        maxHealth = health;
        defaultMat = gameObject.GetComponent<SpriteRenderer>().material;
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
            float damage = collider.gameObject.GetComponent<Damage>().damage;
            TakeDamage(damage);
            
            // destroy attack projectile
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "Poison" && gameObject.tag == "Goblin")
        {
            damageOverTimeTicks = 10;
            StartCoroutine(DoT());
        }
    }

    IEnumerator DoT()
    {
        TakeDamage(.5f);
        yield return new WaitForSeconds(.25f);
        damageOverTimeTicks--;

        if (damageOverTimeTicks > 0)
            StartCoroutine(DoT());
    }

    void TakeDamage(float attackerDamage)
    {
        // flash
        health -= attackerDamage;
        StartCoroutine(Flash());
        
        // hit number
        GameObject newHit = hitNumber;
        newHit.transform.GetChild(0).GetComponent<TMP_Text>().text = "-" + attackerDamage.ToString();
        Instantiate(hitNumber, transform.position, Quaternion.identity);

        if (health <= 0)
        {
            if (!dead)
            {
                print("gain" + coinsGranted + "coins");
                GameObject.Find("HomeBase").GetComponent<HomeManager>().coins += coinsGranted;
                // add some death effect here
                Destroy(gameObject);
            }
            dead = true;
            death.Play();
            deathParticle.Play();
        }
    }

    IEnumerator Flash()
    {
        gameObject.GetComponent<SpriteRenderer>().material = flashMat;
        yield return new WaitForSeconds(.25f);
        gameObject.GetComponent<SpriteRenderer>().material = defaultMat;
    }
}