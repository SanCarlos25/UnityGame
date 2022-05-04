using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used to play audio when the user enters a certain area
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

    // plays the audio when the user enters a certain area
    private void OnTriggerEnter2D()
    {
        // only plays on the first time entry
        if (!FirstTimeEntry) return;
        audioSrc.PlayOneShot(clip);
        FirstTimeEntry = false;
    }
}
