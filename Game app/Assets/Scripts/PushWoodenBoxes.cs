using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushWoodenBoxes : MonoBehaviour
{
    private AudioSource audioSrc;
    private int currentPushingState;    
    public AudioClip Pushing;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  
        if (other.gameObject.CompareTag("PLAYER"))
        {
            //Debug.Log("Selected_character = " + currentPushingState);
            audioSrc.clip = Pushing;
            audioSrc.Play();
        } 
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Full Stop ");
        audioSrc.Stop();       
    }
}
