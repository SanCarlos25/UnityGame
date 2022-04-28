using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private AudioSource AudioSource;
    //private AudioMixMode MixMode;

    public void OnChangeSlider(float Value)
    {
        Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
    }
}
