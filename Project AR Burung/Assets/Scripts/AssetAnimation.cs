using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetAnimation : MonoBehaviour
{
    [Header("Animation Move")]
    [SerializeField] AnimationType animationType;

    [ShowIf(nameof(animationType), AnimationType.Rotate)]
    [SerializeField] int endRotation;

    [ShowIf(nameof(animationType), AnimationType.Position)]
    [SerializeField] int endPosition;

    [Header("DG Set Up")]
    [SerializeField] float animationDuration;
    [SerializeField] Ease animationEase;

    private enum AnimationType
    {
        Rotate, Position
    }

    private void Start()
    {
        PlayAnimation();
    }

    void PlayAnimation()
    {
        switch (animationType)
        {
            case AnimationType.Rotate:
                transform.DOLocalRotate(new Vector3(0f, 0f, endRotation), animationDuration).SetEase(animationEase).SetLoops(-1, LoopType.Yoyo);
                break;
            case AnimationType.Position:
                transform.DOMoveY(endPosition, animationDuration).SetEase(animationEase).SetLoops(-1, LoopType.Yoyo);
                break;
        }
    }

    void Update()
    {
        //PlayAnimation();
    }
}
