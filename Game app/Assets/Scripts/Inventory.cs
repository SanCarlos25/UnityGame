using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject InstructionsUI;
    public GameObject Instructions_In_Inventory;
    public GameObject RiddleUserInterface;

    public GameObject RiddleInInventory;
    public static bool ChestStatus;
    public static bool RiddleStatus;

    public void OpenInventory()
    {
        // displays the inventory UI
        InventoryUI.SetActive(true);
        CheckInstructionsStatus();
        CheckRiddleStatus();

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

    public void OpenInstructions()
    {
        InstructionsUI.SetActive(true);
    }

    public void CloseInstructions()
    {
        InstructionsUI.SetActive(false);
        CheckInstructionsStatus();
    }

    public void CheckInstructionsStatus()
    {
        ChestStatus = FirstLevel.ChestClick;
        if (ChestStatus)
        {
            Instructions_In_Inventory.SetActive(true);
        }
        else
        {
            Instructions_In_Inventory.SetActive(false);
        }
    }

    public void OpenRiddle()
    {
        RiddleUserInterface.SetActive(true);
    }

    public void CloseRiddle()
    {
        RiddleUserInterface.SetActive(false);
        CheckRiddleStatus();
    }

    public void CheckRiddleStatus()
    {
        RiddleStatus = RiddleUI.RiddleTrigger;
        if (RiddleStatus)
        {
            RiddleInInventory.SetActive(true);
        }
        else
        {
            RiddleInInventory.SetActive(false);
        }
    }


}
