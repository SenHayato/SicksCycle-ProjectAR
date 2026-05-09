using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NomorHP : MonoBehaviour
{
    public TMP_InputField inputField;

    void Start()
    {
        // Menambahkan listener untuk menangani perubahan nilai pada input field
        inputField.onValueChanged.AddListener(delegate { ValidateInput(); });
    }

    void ValidateInput()
    {
        // Mengambil nilai dari input field
        string input = inputField.text;

        // Mengecek apakah nilai input merupakan angka integer
        if (!string.IsNullOrEmpty(input) && !int.TryParse(input, out int result))
        {
            // Jika tidak valid, bisa memberikan feedback atau manipulasi input
            Debug.Log("Input harus berupa angka!");
            // Misalnya, menghapus karakter terakhir yang tidak valid
            inputField.text = input.Substring(0, input.Length - 1);
        }
    }
}
