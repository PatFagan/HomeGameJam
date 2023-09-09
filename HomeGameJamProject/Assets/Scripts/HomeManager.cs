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

    public void SpawnGrunt()
    {
        int cost = 1;
        if (coins >= cost)
        {
            coins -= cost;
            Instantiate(gnomes[0], gnomeSpawn.position, Quaternion.identity);
        }
    }

    public void SpawnScout()
    {
        int cost = 2;
        if (coins >= cost)
        {
            coins -= cost;
            Instantiate(gnomes[1], gnomeSpawn.position, Quaternion.identity);
        }
    }

    public void SpawnHealer()
    {
        int cost = 4;
        if (coins >= cost)
        {
            coins -= cost;
            Instantiate(gnomes[2], gnomeSpawn.position, Quaternion.identity);
        }
    }
}
