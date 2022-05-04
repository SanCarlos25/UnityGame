using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AltarUI : MonoBehaviour
{
    public static bool ShrineTrigger = false;
    public GameObject ShrineUI;

    // displays the statues description when the user gets close to the statue
    private void OnTriggerEnter2D()
    {
        ShrineUI.SetActive(true);
    }
    // closes the description when the user clicks the x button
    public void CloseUI()
    {
        ShrineUI.SetActive(false);
    }


}
