using MLAPI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool MenuOpen = false;
    public GameObject pauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

        {
            if (MenuOpen)   // BUG Ei tohiks saada avada kui mäng on läbi
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        MenuOpen = false;
    }

    public void Pause() // BUG ei pane mängu pausile
    {
        pauseMenuUi.SetActive(true);
        MenuOpen = true;
    }

    public void LoadMenu()  // TODO Dubleerib klassi WinMenu ja LooseMenu meetodit
    {
        NetworkManager.Singleton.StopHost();    // TODO Kui on host, siis peaks clientid droppima ja sealt edasi clienti menüüsse edasi suunama
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()  // TODO Dubleerib klassi WinMenu ja LooseMenu meetodit
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}