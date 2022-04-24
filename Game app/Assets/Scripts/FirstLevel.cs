using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel : MonoBehaviour
{
    public GameObject Chest_Open;
    public GameObject Chest_Closed;
    public static bool ChestClick = false;
    public GameObject Instructions;
    public GameObject Inventory;
    public AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // called when player gets close to the chest
    private void OnTriggerEnter2D()
    {
        // opens chest and triggers UI If the chest hasnt been opened
        if (ChestClick) return;
        OpenChest();
        // waits for the animation of the chest opening before activiating UI
        StartCoroutine(WaitForChestOpen());
    }

    // "Opens" the chest by making the opened chest game object active
    void OpenChest()
    {
        //Chest_Closed.SetActive(false);
        Chest_Open.SetActive(true);
        ChestClick = true;
    }

    // Waits .5 seconds for chest to open then triggers UI
    IEnumerator WaitForChestOpen()
    {
        yield return new WaitForSeconds(.5f);
        
        Instructions.SetActive(true);
        Inventory.SetActive(true);
        Time.timeScale = 0f;

    }

}