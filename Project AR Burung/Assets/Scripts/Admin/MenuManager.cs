using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string ARScene;

    public void LoadtoAR()
    {
        SceneManager.LoadSceneAsync(ARScene);
        Debug.Log("Load Scene");
    }

    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("APP Quit");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication();
        }
    }
}
