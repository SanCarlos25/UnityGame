using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// manages the sound effects slider
public class AudioSlider : MonoBehaviour
{
    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private AudioSource AudioSource;
    //private AudioMixMode MixMode;

    // makes the slider in unity go up as the user adjusts the one in the UI
    public void OnChangeSlider(float Value)
    {
        Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
    }
}
