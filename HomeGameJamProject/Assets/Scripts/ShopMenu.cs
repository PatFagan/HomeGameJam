using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopMenu : MonoBehaviour
{
    public bool isActive;
    public GameObject UpgradeMenu;
    // Start is called before the first frame update
    void Start()
    {
        UpgradeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpgradeMenu.SetActive(isActive);
    }
}
