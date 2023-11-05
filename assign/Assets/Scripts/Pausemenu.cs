using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] GameObject Pausemenu;
    public void Pause()
    {
        Pausemenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Pausemenu?.SetActive(false);
        Time.timeScale = 1;

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }

    public void Restart()
    { 
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;

    }

    public void Quit()
    {
        Application.Quit();
    }
}