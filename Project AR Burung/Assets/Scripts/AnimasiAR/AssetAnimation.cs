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
    [SerializeField] Ease animationEase;

    private enum AnimationType
    {
        Rotate, Position
    }

    private void Awake()
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

    private void Start()
    {
        if (introAnimation != null)
        {
            Invoke(nameof(PlayAnimation), introAnimation.clip.length + 0.2f);
        }
        else
        {
            PlayAnimation();
        }
    }

    void PlayAnimation()
    {
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
}
