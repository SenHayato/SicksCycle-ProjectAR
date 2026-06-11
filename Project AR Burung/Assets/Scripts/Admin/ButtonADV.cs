using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonADV : Button
{
    [SerializeField] Color transparent = new Color(255f, 255f, 255f, 0f);
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Vector2 normalSize;
    [SerializeField] float sizeUp;

    protected override void Start()
    {
        targetGraphic.color = transparent;
        rectTransform = GetComponent<RectTransform>();
        normalSize = rectTransform.sizeDelta;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        targetGraphic.DOColor(Color.white, 0.15f).SetEase(Ease.OutSine);
        if (sizeUp > 0f)
        {
            rectTransform.DOSizeDelta(normalSize * sizeUp, 0.15f).SetEase(Ease.OutSine);
        }
        //Debug.Log("Button Masuk");
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        targetGraphic.DOColor(transparent, 0.15f).SetEase(Ease.OutSine);
        if (sizeUp > 0f)
        {
            rectTransform.DOSizeDelta(normalSize, 0.15f).SetEase(Ease.OutSine);
        }
        //Debug.Log("Button Exit");
    }
}
