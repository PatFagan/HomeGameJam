using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public GameObject homeBaseMenu;

    public GameObject[] gnomes;

    public Transform gnomeSpawn;

    public int coins;
    public TMP_Text coinDisplay;

    bool spawnCoolingDown = false;

    // upgrades
    bool healthUpgraded = false;
    bool attackUpgraded = false;

    // Start is called before the first frame update
    void Start()
    {
        coins = 10;
    }

    // Update is called once per frame
    void Update()
    {
        coinDisplay.text = "Coins: " + coins.ToString();

        if (Input.GetButtonDown("Escape"))
        {
            Application.Quit();
        }
    }

    public void SpawnGrunt()
    {
        int cost = 1;
        if (coins >= cost && spawnCoolingDown == false)
        {
            coins -= cost;
            SpawnGnome(0);
            StartCoroutine(Cooldown());
        }
    }

    public void SpawnScout()
    {
        int cost = 2;
        if (coins >= cost && spawnCoolingDown == false)
        {
            coins -= cost;
            SpawnGnome(1);
            StartCoroutine(Cooldown());
        }
    }

    public void SpawnHealer()
    {
        int cost = 4;
        if (coins >= cost && spawnCoolingDown == false)
        {
            coins -= cost;
            SpawnGnome(2);
            StartCoroutine(Cooldown());
        }
    }

    public void SpawnMage()
    {
        int cost = 100;
        if (coins >= cost && spawnCoolingDown == false)
        {
            coins -= cost;
            SpawnGnome(3);
            StartCoroutine(Cooldown());
        }
    }

    void SpawnGnome(int index)
    {
        GameObject gnomeSpawn = gnomes[index];

        if (healthUpgraded)
        {
            gnomeSpawn.GetComponent<HealthManager>().health *= 2f;
        }

        if (attackUpgraded)
        {
            if (gnomeSpawn.tag != "Poison")
                gnomeSpawn.GetComponent<GnomeAttacks>().timeBetweenAttacks = .5f;
        }
        
        Instantiate(gnomeSpawn, gnomeSpawn.transform.position, Quaternion.identity);
    }

    public void UpgradeHutHealth()
    {
        int cost = 10;
        if (coins >= cost)
        {
            coins -= cost;
            gameObject.GetComponent<HomeHealthManager>().maxHealth += 10f;
            gameObject.GetComponent<HomeHealthManager>().health += 15f;
        }
    }

    public void UpgradeGnomeHealth()
    {
        int cost = 15;
        if (coins >= cost)
        {
            coins -= cost;
            healthUpgraded = true;
        }
    }

    public void UpgradeGnomeAttack()
    {
        int cost = 20;
        if (coins >= cost)
        {
            coins -= cost;
            attackUpgraded = true;
        }
    }

    public void UpgradeGoblinValue()
    {
        int cost = 30;
        if (coins >= cost)
        {
            coins -= cost;
            //healthUpgraded = true;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    IEnumerator Cooldown()
    {
        spawnCoolingDown = true;
        yield return new WaitForSeconds(1f);
        spawnCoolingDown = false;
    }
}
