using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void Level(string sceneName)
    { 
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);  
        

    }
}
