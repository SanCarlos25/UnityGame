using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSound : MonoBehaviour
{
    private AudioSource audioSrc;
    private Rigidbody2D rb;
    private int currentPushingState;
    private bool Moved = false;
    public GameObject Glow;
    public AudioClip Pushing;
    

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //currentPushingState;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  
        if (other.gameObject.CompareTag("PLAYER"))
        {
            Debug.Log("Selected_character = " + currentPushingState);
            audioSrc.clip = Pushing;
            audioSrc.Play();
        } 
        if (!Moved)
        {
            Glow.SetActive(false);
            Moved = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Full Stop ");
        audioSrc.Stop();       
    }
    
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Selected_character = " + currentPushingState);
        if(currentPushingState == 1)
        {
            audioSrc.clip = Pushing;
            audioSrc.Play();
        }
        
        
    }*/

    

}
