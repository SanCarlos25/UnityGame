using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private static AudioManager backgroundmusic;

    private void Awake()
    {
        if (backgroundmusic == null)
        {
            backgroundmusic = this;
            DontDestroyOnLoad(backgroundmusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /*private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("BGM");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }*/
}