using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminActive : MonoBehaviour
{
    //tambah fitur max frame rate dan keluar aplikasi
    [SerializeField] int maxFrameRate;
    [SerializeField] string menuScene;
    void Start()
    {
        Application.targetFrameRate = maxFrameRate;
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(menuScene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenu();
        }
    }
}
