using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

// script no longer used in the project
public class SourEffectsSlider : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string SoundEffectsPreff = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider soundEffectsSlider;
    private float soundEffectsFloat;
    public AudioSource[] soundEffectsAudio;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            soundEffectsFloat = .5f;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(SoundEffectsPreff, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPreff);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(SoundEffectsPreff, soundEffectsFloat);

    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        //soundEffectsAudio.volume = soundEffectsSlider.value;

        for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }
}
