using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MLAPI;
using MLAPI.Transports.UNET;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public TextMeshProUGUI IPtext;
    public string input;
    public void PlayGame()
    {
        SceeneData.HostOrJoin = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void JoinGame(string IP)
    {
        input = IP;
        SceeneData.HostOrJoin = IP;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
