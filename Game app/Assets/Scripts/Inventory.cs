using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages the inventory
public class Inventory : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject InstructionsUI;
    public GameObject Instructions_In_Inventory;
    public GameObject RiddleUserInterface;

    public GameObject RiddleInInventory;
    public static bool ChestStatus;
    public static bool RiddleStatus;

    // displays the inventory ui
    public void OpenInventory()
    {
        // displays the inventory UI
        InventoryUI.SetActive(true);

        // checks to see if the instructions or the riddle has been triggered yet
        CheckInstructionsStatus();
        CheckRiddleStatus();

        // pauses time
        Time.timeScale = 0f;
    }

    // closes the inventory UI
    public void CloseInventory()
    {
        // undisplays the inventory UI
        InventoryUI.SetActive(false);
        // unpauses time
        Time.timeScale = 1f;
    }

    // displays the instructions UI
    public void OpenInstructions()
    {
        InstructionsUI.SetActive(true);
    }

    //closes the instructions UI
    public void CloseInstructions()
    {
        InstructionsUI.SetActive(false);
        CheckInstructionsStatus();
    }

    // checks to see if the instructions are supposed to be in the inventory or not
    public void CheckInstructionsStatus()
    {
        ChestStatus = FirstLevel.ChestClick;
        // if they are, then it displays the instructions button in the inventory
        if (ChestStatus)
        {
            Instructions_In_Inventory.SetActive(true);
        }
        // if not it doesnt display them
        else
        {
            Instructions_In_Inventory.SetActive(false);
        }
    }

    // displays the riddle UI
    public void OpenRiddle()
    {
        RiddleUserInterface.SetActive(true);
    }

    // closes the riddle UI
    public void CloseRiddle()
    {
        RiddleUserInterface.SetActive(false);
        CheckRiddleStatus();
    }

    // checks to see if the riddle is supposed to be in the inventory or not
    public void CheckRiddleStatus()
    {
        RiddleStatus = RiddleUI.RiddleTrigger;
        // if it is, then it displays the riddle button in the inventory
        if (RiddleStatus)
        {
            RiddleInInventory.SetActive(true);
        }
        // if not, it doesnt
        else
        {
            RiddleInInventory.SetActive(false);
        }
    }


}
