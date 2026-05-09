using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoVolume : MonoBehaviour
{
    // Misalnya, di dalam script yang terhubung dengan slider
    public VideoPlayer[] videos;

    public void SetVolume(float sliderValue)
    {
        foreach (VideoPlayer videos in videos)
        {
            videos.SetDirectAudioVolume(0, sliderValue);
        }
    }

}
