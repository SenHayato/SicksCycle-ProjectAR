using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxVolume : MonoBehaviour
{
    // Misalnya, di dalam script yang terhubung dengan slider
    public AudioSource[] audioSources;

    public void SetVolume(float sliderValue)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = sliderValue;
        }
    }

}
