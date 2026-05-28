using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetAnimation : MonoBehaviour
{
    [Header("Animation Move")]
    [SerializeField] AnimationType animationType;
    [SerializeField] Animation introAnimation;

    [ShowIf(nameof(animationType), AnimationType.Rotate)]
    [SerializeField] float startRotation, endRotation;

    [ShowIf(nameof(animationType), AnimationType.Position)]
    [SerializeField] Vector3 startPosition,endPosition;

    [Header("DG Set Up")]
    [SerializeField] float animationDuration;
    [SerializeField] float timeBeforeTween;
    [SerializeField] Ease animationEase;

    private enum AnimationType
    {
        Rotate, Position
    }

    private void StartDG()
    {
        switch (animationType)
        {
            case AnimationType.Rotate:
                transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, startRotation);
                break;
            case AnimationType.Position:
                transform.localPosition = startPosition;
                break;
        }
    }

    private void OnEnable()
    {
        StartDG();

        if (introAnimation != null)
        {
            Invoke(nameof(PlayAnimation), introAnimation.clip.length + timeBeforeTween);
        }
        else
        {
            PlayAnimation();
        }
    }

    void PlayAnimation()
    {
        transform.DOKill();

        switch (animationType)
        {
            case AnimationType.Rotate:
                transform.DOLocalRotate(new Vector3(0f, 0f, endRotation), animationDuration).SetEase(animationEase).SetLoops(-1, LoopType.Yoyo);
                break;
            case AnimationType.Position:
                transform.DOLocalMove(endPosition, animationDuration).SetEase(animationEase).SetLoops(-1, LoopType.Yoyo);
                break;
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
        transform.DOKill();
    }
}
