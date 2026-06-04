using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminActive : MonoBehaviour
{
    //tambah fitur max frame rate dan keluar aplikasi
    [SerializeField] int maxFrameRate;
    void Start()
    {
        Application.targetFrameRate = maxFrameRate;
    }

    public void ExitApplication()
    {
        Application.Quit();
        Debug.Log("Quit APP");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitApplication();
        }
    }
}
