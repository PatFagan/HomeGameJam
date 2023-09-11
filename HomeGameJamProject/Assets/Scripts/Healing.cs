using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healing : MonoBehaviour
{
    GameObject gnomeHealed;
    public GameObject hitNumber;

    bool healingNow = false;

    void Start()
    {
        StartCoroutine(HealthLoop());
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Gnome" && collider.gameObject.name != "GnomeHealer(Clone)")
        {
            gnomeHealed = collider.gameObject;
            healingNow = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Gnome")
        {
            healingNow = false;
        }
    }

    IEnumerator HealthLoop()
    {
        if (healingNow)
        {
            float healthHealed = .5f;

            if (gnomeHealed.GetComponent<HealthManager>().health <= gnomeHealed.GetComponent<HealthManager>().maxHealth)
                gnomeHealed.GetComponent<HealthManager>().health += healthHealed;
                
            // hit number
            GameObject newHit = hitNumber;
            newHit.transform.GetChild(0).GetComponent<TMP_Text>().text = "+" + healthHealed.ToString();
            Instantiate(hitNumber, gnomeHealed.transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(.3f);
        StartCoroutine(HealthLoop());
    }
}
