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
            Instantiate(gnomes[0], gnomeSpawn.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
    }

    public void SpawnScout()
    {
        int cost = 2;
        if (coins >= cost && spawnCoolingDown == false)
        {
            coins -= cost;
            Instantiate(gnomes[1], gnomeSpawn.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
    }

    public void SpawnHealer()
    {
        int cost = 4;
        if (coins >= cost && spawnCoolingDown == false)
        {
            coins -= cost;
            Instantiate(gnomes[2], gnomeSpawn.position, Quaternion.identity);
            StartCoroutine(Cooldown());
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
