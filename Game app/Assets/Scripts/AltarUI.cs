using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AltarUI : MonoBehaviour
{
    public static bool ShrineTrigger = false;
    public GameObject ShrineUI;

    private void OnTriggerEnter2D()
    {
        ShrineUI.SetActive(true);
    }
    
    public void CloseUI()
    {
        ShrineUI.SetActive(false);
    }


}
