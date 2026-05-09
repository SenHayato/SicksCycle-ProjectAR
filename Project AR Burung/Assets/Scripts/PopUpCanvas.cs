using UnityEngine;

public class PopUpCanvas : MonoBehaviour
{
    public GameObject ARCamera;
    public Canvas PopCanvas;

    void Awake()
    {
        ARCamera = GameObject.FindGameObjectWithTag("MainCamera");
        PopCanvas = GetComponent<Canvas>();
        //PopCanvas.worldCamera = Camera.main;
    }
}
