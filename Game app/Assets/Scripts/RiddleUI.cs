using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleUI : MonoBehaviour
{
    public static bool RiddleTrigger = false;
    public GameObject RiddleUserInterface;

    // triggers the Riddle UI to pop up when the user gets in the trigger box
    private void OnTriggerEnter2D()
    {
        if (RiddleTrigger) return;
        RiddleUserInterface.SetActive(true);
        RiddleTrigger = true;
    }
}
