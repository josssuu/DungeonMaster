using MLAPI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour    // TODO Dubleerib LooseMenu classi
{
    public void LoadMenu()  // TODO Dubleerib klassi PauseMenu ja LooseMenu meetodit
    {
        NetworkManager.Singleton.StopHost();    // TODO Kui on host, siis peaks clientid droppima ja sealt edasi clienti menüüsse edasi suunama
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()  // TODO Dubleerib klassi PauseMenu ja LooseMenu meetodit
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}