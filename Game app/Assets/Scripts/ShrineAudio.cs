using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]

public class ShrineAudio : MonoBehaviour
{
    private AudioSource audioSrc;
    public AudioClip clip;
    private bool FirstTimeEntry = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // plays the shrine audio if the user hasnt entered the area before
    private void OnTriggerEnter2D()
    {
        // opens chest and triggers UI If the chest hasnt been opened
        if (!FirstTimeEntry) return;
        audioSrc.PlayOneShot(clip, .7f);
        FirstTimeEntry = false;
    }
}
