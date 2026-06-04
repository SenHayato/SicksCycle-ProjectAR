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

    void ExitApplication()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitApplication();
        }
    }
}
