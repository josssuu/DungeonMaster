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
    /*
    private void Awake()
    {

        string data = SceeneData.HostOrJoin;
        Debug.Log(data);
        Debug.Log("EELMINE");
        if(data != null)
        {
            UNetTransport unet = NetworkManager.Singleton.GetComponent<UNetTransport>();
            unet.ConnectAddress = data;
            NetworkManager.Singleton.StartClient();
        }
        else
        {
            NetworkManager.Singleton.StartHost();
        }
        
    }
    */
    void Update()
    {
        
        
        
    }

    public void IPChanged(string newIP)
    {
        IP = newIP;
    }
}
