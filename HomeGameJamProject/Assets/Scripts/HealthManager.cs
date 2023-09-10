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
            print(gameObject.name);

            float damage = collider.gameObject.GetComponent<Damage>().damage;
            health -= damage;
            StartCoroutine(Flash());

            // destroy attack projectile
            Destroy(collider.gameObject);

            if (health <= 0)
            {
                if (!dead)
                {
                    print("gain" + coinsGranted + "coins");
                    GameObject.Find("HomeBase").GetComponent<HomeManager>().coins += coinsGranted;
                    // add some death effect here
                    GameObject newHit = hitNumber;
                    newHit.transform.GetChild(0).GetComponent<TMP_Text>().text = "-" + damage.ToString();
                    Instantiate(hitNumber, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                dead = true;
            }
        }
    }

    IEnumerator Flash()
    {
        gameObject.GetComponent<SpriteRenderer>().material = flashMat;
        yield return new WaitForSeconds(.25f);
        gameObject.GetComponent<SpriteRenderer>().material = defaultMat;
    }
}