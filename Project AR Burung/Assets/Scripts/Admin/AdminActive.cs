using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminActive : MonoBehaviour
{
    public static AdminActive instance {  get; private set; }

    //tambah fitur max frame rate dan keluar aplikasi
    [SerializeField] int maxFrameRate;
    [SerializeField] string menuScene;
    [SerializeField] AudioSource buttonSFX;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        Application.targetFrameRate = maxFrameRate;
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(menuScene);
    }

    public void PlayButtonSound()
    {
        instance.buttonSFX.PlayOneShot(buttonSFX.clip);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenu();
        }
    }
}
