using MLAPI;
using MLAPI.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void HostGame()
    {
        SoundManager.PlaySound("menuClick");
        NetworkManager.Singleton.StartHost();
        NetworkSceneManager.SwitchScene("Lobby");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void JoinGame()
    {
        SoundManager.PlaySound("menuClick");
    }

    public void QuitGame()
    {
        SoundManager.PlaySound("menuClick");
        Debug.Log("QUIT!");
        Application.Quit();
    }
}