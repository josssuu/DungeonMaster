using MLAPI;
using MLAPI.Transports.UNET;
using TMPro;
using UnityEngine;

public class Join : MonoBehaviour
{
    public TMP_InputField IpInputField;
    public string IP;
    private UNetTransport unet;

    private void Awake()
    {
        unet = NetworkManager.Singleton.GetComponent<UNetTransport>();
    }

    public void IPChanged(string newIP)
    {
        IP = newIP;
    }

    public void JoinGame()
    {
        SoundManager.PlaySound("menuClick");
        print(IP);
        unet.ConnectAddress = IP;
        NetworkManager.Singleton.StartClient();
        print(NetworkManager.Singleton.IsConnectedClient);
        /*
        try
        {
            unet.ConnectAddress = IP;
            NetworkManager.Singleton.StartClient();
        }
        catch
        {
            NetworkManager.Singleton.StopClient();
        }*/
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        SoundManager.PlaySound("menuClick");
    }
}