using UnityEngine;
using UnityEngine.SceneManagement;
using MLAPI;

public class LooseMenu : MonoBehaviour // TODO Dubleerib WinMenu classi
{
    public void LoadMenu()  // TODO Dubleerib klassi WinMenu ja PauseMenu meetodit
    {
        NetworkManager.Singleton.StopHost();    // TODO Kui on host, siis peaks clientid droppima ja sealt edasi clienti menüüsse edasi suunama
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()  // TODO Dubleerib klassi WinMenu ja PauseMenu meetodit
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}