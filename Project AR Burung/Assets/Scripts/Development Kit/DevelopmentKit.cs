using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopmentKit : MonoBehaviour
{
    //saat build script ini dihapus + objeknya

    [SerializeField] float fastForward; //default 1
    //[SerializeField] bool isForward; //default false

    private void FixedUpdate()
    {
        Time.timeScale = fastForward;
    }
}
