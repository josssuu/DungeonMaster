using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject WinCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WinCanvas.SetActive(true);
    }
}
