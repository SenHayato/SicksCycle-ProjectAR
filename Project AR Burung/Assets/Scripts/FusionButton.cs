using System.Linq;
using UnityEngine;

public class FusionButton : MonoBehaviour
{
    public bool[] organik = new bool[2];
    public bool[] anorganik = new bool[2];
    public bool[] berbahaya = new bool[2];

    public GameObject OrganikPre;
    public GameObject AnorganikPre;
    public GameObject BerbahayaPre;

    public GameObject ButtonOrg;
    public GameObject ButtonArg;
    public GameObject ButtonBer;

    public void SummonOrganik()
    {
            Vector3 spawnPosition = new (0, 0, 0); // Posisi spawn
            Quaternion spawnRotation = Quaternion.identity; // Rotasi default (tanpa rotasi)

            Instantiate(OrganikPre, spawnPosition, spawnRotation);
            Debug.Log("Semua elemen di organik adalah false");
    }

    public void SummonAnorganik()
    {
            Vector3 spawnPosition = new (0, 0, 0); // Posisi spawn
            Quaternion spawnRotation = Quaternion.identity; // Rotasi default (tanpa rotasi)

            Instantiate(AnorganikPre, spawnPosition, spawnRotation);
            Debug.Log("Semua elemen di organik adalah false");
    }

    public void SummonBerbahaya()
    {
            Vector3 spawnPosition = new (0, 0, 0); // Posisi spawn
            Quaternion spawnRotation = Quaternion.identity; // Rotasi default (tanpa rotasi)

            Instantiate(BerbahayaPre, spawnPosition, spawnRotation);
            Debug.Log("Semua elemen di organik adalah false");
    }

    private void Update()
    {
        if (organik.All(element => element))
        {
            ButtonOrg.SetActive(true);
            Debug.Log("Semua elemen di organik adalah true");
        }
        else
        {   
            ButtonOrg.SetActive(false);
            Debug.Log("Tidak semua elemen di organik adalah true");
        }

        if (anorganik.All(element => element))
        {
            ButtonArg.SetActive(true);
            Debug.Log("Semua elemen di organik adalah true");
        }
        else
        {   
            ButtonArg.SetActive(false);
            Debug.Log("Tidak semua elemen di organik adalah true");
        }

        if (berbahaya.All(element => element))
        {
            ButtonBer.SetActive(true);
            Debug.Log("Semua elemen di organik adalah true");
        }
        else
        {   
            ButtonBer.SetActive(false);
            Debug.Log("Tidak semua elemen di organik adalah true");
        }
    }
}
