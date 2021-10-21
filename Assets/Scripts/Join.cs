using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using TMPro;
using MLAPI.Transports.UNET;

public class Join : MonoBehaviour
{
    public TextMeshProUGUI IPtext;
    public string IP;

    void Update()
    {
        //Debug.Log(IPtext.text);
        if (Input.GetKeyDown(KeyCode.H))
        {
            NetworkManager.Singleton.StartHost();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            UNetTransport unet = NetworkManager.Singleton.GetComponent<UNetTransport>();
            unet.ConnectAddress = IP;
            NetworkManager.Singleton.StartClient();
        }
    }

    public void IPChanged(string newIP)
    {
        IP = newIP;
    }
}
