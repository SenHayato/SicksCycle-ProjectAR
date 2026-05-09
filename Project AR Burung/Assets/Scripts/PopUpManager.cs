using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject PopUp;
    public bool isEnabled;

    private void Start()
    {
        isEnabled = false;
    }

    public void PopUpActive()
    {
        if (isEnabled)
        {
            PopUp.SetActive(true);
        }
        else
        {
            PopUp.SetActive(false);
        }
    }

    private void Update()
    {
        PopUpActive();
    }
}
