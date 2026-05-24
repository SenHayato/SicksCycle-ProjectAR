using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] Image textBackground;
    [SerializeField] float backgroundAlphaValue;
    [SerializeField] float textFadeDuration;
    [SerializeField] AudioSource dialogueAudio;

    Coroutine dialogueCoroutine;

    float maxAlphaText;
    float maxAlphaBackground;
    private void Awake()
    {
        maxAlphaText = dialogueText.color.a;
        maxAlphaBackground = textBackground.color.a;
    }

    void AlphaFadeIn()
    {
        dialogueText.DOFade(1f, textFadeDuration).SetEase(Ease.Linear);
        textBackground.DOFade(backgroundAlphaValue, textFadeDuration).SetEase(Ease.Linear);
    }

    void AlphaFadeOut()
    {
        dialogueText.DOFade(0f, textFadeDuration).SetEase(Ease.Linear);
        textBackground.DOFade(0f, textFadeDuration).SetEase(Ease.Linear);
    }

    private void OnEnable()
    {
        currentIndex = 0;
        if (!dialogueText.enabled)
        {
            dialogueText.enabled = true;
        }

        if (dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
        }

        Color textTransparent = dialogueText.color;
        textTransparent.a = 0f;
        dialogueText.color = textTransparent;

        Color backTransparent = textBackground.color;
        backTransparent.a = 0f;
        textBackground.color = backTransparent;

        dialogueCoroutine = StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        while (currentIndex < dialogues.Count)
        {
            DialogueLine line = dialogues[currentIndex];

            dialogueText.text = line.text;

            dialogueAudio.clip = line.voiceClip;
            dialogueAudio.Play();

            AlphaFadeIn();

            float waitTime = Mathf.Max(0, line.voiceClip.length - textFadeDuration);

            // jeda ampek voice playback selesai
            yield return new WaitForSeconds(waitTime);

            AlphaFadeOut();

            yield return new WaitForSeconds(textFadeDuration);

            currentIndex++;
        }

        //dialogueText.enabled = false;
        AlphaFadeOut();
    }

    private void OnDisable()
    {
        if (dialogueCoroutine != null)
        {
            StopCoroutine(PlayDialogue());
            dialogueCoroutine = null;
        }

        dialogueAudio.Stop();
    }
}
