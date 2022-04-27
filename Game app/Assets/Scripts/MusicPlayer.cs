using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    public GameObject backgroundmusic;
    public AudioSource bgm;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",0.02f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        if (backgroundmusic == null)
        {
            backgroundmusic = GameObject.FindWithTag("BGM");
        }

        bgm = backgroundmusic.GetComponent<AudioSource>();
        //AudioListener.volume = volumeSlider.value;
        bgm.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    
}
