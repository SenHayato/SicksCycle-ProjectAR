using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowPassword : MonoBehaviour
{
    public TMP_InputField userPassword;
    public Image buttonIcon;

    [Header("Icon Tombol")]
    public Sprite defaultIcon;
    public Sprite hideIcon;

    private void Start()
    {

        userPassword.contentType = TMP_InputField.ContentType.Password;

        userPassword.ForceLabelUpdate();
    }

    public void ShowUserPassword()
    {
        if (userPassword.contentType == TMP_InputField.ContentType.Password)
        {
            userPassword.contentType = TMP_InputField.ContentType.Standard;
            buttonIcon.sprite = defaultIcon;
        }
        else
        {
            userPassword.contentType = TMP_InputField.ContentType.Password;
            buttonIcon.sprite = hideIcon;
        }
        userPassword.ForceLabelUpdate();
    }
}