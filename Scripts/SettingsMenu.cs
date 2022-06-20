using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider voiceSlider;
    public AudioMixer audioMixer;
    private float volume;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    void Update()
    {
        audioMixer.GetFloat("volume",out volume);
        voiceSlider.value = volume;
    }
}
