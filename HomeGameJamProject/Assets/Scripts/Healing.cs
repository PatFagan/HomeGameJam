using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Gnome")
        {
            collider.gameObject.GetComponent<HealthManager>().health += .1f;
        }
    }
}
