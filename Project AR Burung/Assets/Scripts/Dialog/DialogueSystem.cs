using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class DialogueLine //Sesuaikan dialog, banyak dialog, dan voice playback
{
    [TextArea] public string text;
    public AudioClip voiceClip;
}

public class DialogueSystem : MonoBehaviour
{
    [Header("Dialogue List")]
    [SerializeField] List<DialogueLine> dialogues;
    int currentIndex = 0;

    [Header("Dialogue Component")]
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] AudioSource dialogueAudio;

    private void Awake()
    {
        if (!dialogueText.enabled)
        {
            dialogueText.enabled = true;
        }
    }

    private void Start()
    {
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        while (currentIndex < dialogues.Count)
        {
            DialogueLine line = dialogues[currentIndex];

            dialogueText.text = line.text;

            dialogueAudio.clip = line.voiceClip;
            dialogueAudio.Play();

            // jeda ampek voice playback selesai
            yield return new WaitForSeconds(line.voiceClip.length);

            currentIndex++;
        }

        dialogueText.enabled = false;
    }
}
