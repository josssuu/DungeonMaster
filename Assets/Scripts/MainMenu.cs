using TMPro;
using UnityEngine;
using MLAPI;
using MLAPI.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void HostGame()
    {
        SoundManager.PlaySound("menuClick");
        NetworkManager.Singleton.StartHost();
        NetworkSceneManager.SwitchScene("Lobby");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        SoundManager.PlaySound("menuClick");
        Debug.Log("QUIT!");
        Application.Quit();
    }
}