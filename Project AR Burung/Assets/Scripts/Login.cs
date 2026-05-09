using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public TMP_InputField usernameInputField;
    public TMP_InputField passwordInputField;
    public Button loginButton;

    // Data nama dan sandi yang sesuai dengan yang kamu miliki
    [Header("Data Akun")]
    public string nama;
    public string sandi;

    void Start()
    {
        // Matikan tombol login saat game dimulai
        loginButton.interactable = false;
    }

    void Update()
    {
        // Cek input field setiap frame untuk memutuskan apakah tombol login harus diaktifkan
        CheckInputFields();
    }

    void CheckInputFields()
    {
        // Ambil teks dari input field username dan password
        string inputUsername = usernameInputField.text;
        string inputPassword = passwordInputField.text;

        if (inputUsername == nama && inputPassword == sandi)
        {
            loginButton.interactable = true;
        }
        else
        {
            loginButton.interactable = false;
        }
    }
}
