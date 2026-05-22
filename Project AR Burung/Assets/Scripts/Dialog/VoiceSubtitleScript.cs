using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class SubtitleData
{
    public float startTime;
    public float endTime;
    public string text;
}

public class VoiceSubtitleScript : MonoBehaviour
{
    [Header("Subtitle Component")]
    [SerializeField] List<SubtitleData> subtitles;
    [SerializeField] TextMeshProUGUI subtitleText;

    [Header("Audio Clip")]
    [SerializeField] AudioClip audioClip;

    [Header("Audio Component")]
    [SerializeField] AudioSource voiceSource;

    void Start()
    {
        voiceSource.clip = audioClip;
    }

    void SubtitlePlay()
    {
        float currentTime = voiceSource.time;

        foreach (var sub in subtitles)
        {
            if (currentTime >= sub.startTime &&
                currentTime <= sub.endTime)
            {
                subtitleText.text = sub.text;
                return;
            }
        }

        //subtitleText.text = "";
    }

    void Update()
    {
        SubtitlePlay();
    }
}
