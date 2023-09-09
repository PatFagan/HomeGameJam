using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeManager : MonoBehaviour
{
    public GameObject homeBaseMenu;

    public GameObject[] gnomes;

    public Transform gnomeSpawn;

    public int coins;
    public TMP_Text coinDisplay;

    // Start is called before the first frame update
    void Start()
    {
        coins = 10;
    }

    // Update is called once per frame
    void Update()
    {
        coinDisplay.text = "Coins: " + coins.ToString();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            homeBaseMenu.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            homeBaseMenu.SetActive(false);
        }
    }

    public void SpawnGrunt()
    {
        int cost = 1;
        if (coins >= cost)
        {
            coins -= cost;
            Instantiate(gnomes[0], gnomeSpawn.position, Quaternion.identity);
        }
    }
}
