using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public GameObject InventoryUI;

    public void OpenInventory()
    {
        // displays the inventory UI
        InventoryUI.SetActive(true);
        // pauses time
        Time.timeScale = 0f;
    }

    public void CloseInventory()
    {
        // undisplays the inventory UI
        InventoryUI.SetActive(false);
        // unpauses time
        Time.timeScale = 1f;
    }

}
