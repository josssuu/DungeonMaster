using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI IPtext;
    public string input;

    public void PlayGame()
    {
        SoundManager.PlaySound("menuClick");
        SceeneData.HostOrJoin = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        SoundManager.PlaySound("menuClick");
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void JoinGame(string IP)
    {
        SoundManager.PlaySound("menuClick");
        input = IP;
        SceeneData.HostOrJoin = IP;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}