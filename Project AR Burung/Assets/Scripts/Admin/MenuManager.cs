using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [Header("Menu Component")]
    [SerializeField] string ARScene;
    [SerializeField] GameObject creditPanel;

    [Header("Menu Button Component")]
    [SerializeField] GameObject ExitButton;
    [SerializeField] GameObject CreditButton;
    [SerializeField] GameObject ScanButton;

    [Header("Button Audio")]
    [SerializeField] AudioSource buttonSFX;

    bool menuButtonToggle = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        creditPanel.SetActive(false);
        MenuButtonToggler();
    }

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

    public void ButtonSoundPlay()
    {
        Instance.buttonSFX.PlayOneShot(buttonSFX.clip);
    }

    public void MenuButtonToggler()
    {
        if (menuButtonToggle)
        {
            menuButtonToggle = false;
        }
        else
        {
            menuButtonToggle = true;
        }

        ExitButton.SetActive(menuButtonToggle);
        CreditButton.SetActive(menuButtonToggle);
        ScanButton.SetActive(menuButtonToggle);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication();
        }
    }
}
