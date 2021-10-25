using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using MLAPI;
using MLAPI.Transports.UNET;

public class MainMenu : MonoBehaviour
{
    //public TextMeshProUGUI IPtext;
    public GameObject input;

    public void PlayGame()
    {
        SoundManager.PlaySound("menuClick");
        NetworkManager.Singleton.StartHost();

        //SceeneData.HostOrJoin = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        SoundManager.PlaySound("menuClick");
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void JoinGame()
    {
        SoundManager.PlaySound("menuClick");
        string ip = input.GetComponent<TMP_InputField>().text;

        //Debug.Log(ip);
        UNetTransport unet = NetworkManager.Singleton.GetComponent<UNetTransport>();
        unet.ConnectAddress = ip;
        NetworkManager.Singleton.StartClient();
        //input = IP;
        //SceeneData.HostOrJoin = IP;
        Debug.Log(SceeneData.HostOrJoin);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}