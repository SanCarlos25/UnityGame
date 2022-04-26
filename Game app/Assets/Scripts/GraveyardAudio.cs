using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardAudio : MonoBehaviour
{
    private AudioSource audioSrc;
    public AudioClip clip;
    private bool FirstTimeEntry = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D()
    {
        // opens chest and triggers UI If the chest hasnt been opened
        if (!FirstTimeEntry) return;
        audioSrc.PlayOneShot(clip);
        FirstTimeEntry = false;
    }
}
