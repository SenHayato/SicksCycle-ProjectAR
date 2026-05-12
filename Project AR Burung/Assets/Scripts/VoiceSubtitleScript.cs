using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoiceSubtitleScript : MonoBehaviour
{
    [Header("Subtitle Component")]
    [SerializeField] int subtitleCount = 0;
    [SerializeField] string[] subtitles;
    int subtitleTotal => subtitles.Length;

    [SerializeField] TextMeshProUGUI subtitleText;

    [Header("Audio Component")]
    [SerializeField] AudioSource voiceSource;

    void TestSub() //Test saja, bikin bisa otomatis menyeseuikan lama dari Voice Acting pas produksi
    {
        if (subtitleCount < subtitles.Length)
        {
            subtitleText.text = subtitles[subtitleCount];
        }
        else
        {
            subtitleText.enabled = false;
            return; //sudah maks tidak dijalankan
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            subtitleCount++;
        }
    }

    void Update()
    {
        TestSub();
    }
}
