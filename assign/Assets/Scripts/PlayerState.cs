using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public int PlayerHealth = 10;
    public int enemyTotal;


    public Button Retry;
    public Button MainMenu;
    public TextMeshProUGUI lose;
    public TextMeshProUGUI win;
    public TextMeshProUGUI hp;
    public Image HPbar;
    
    EnemySpawn enemySpawn;

    void Awake()
    {
        enemySpawn = GameObject.Find("GameControl").GetComponent<EnemySpawn>();
        enemyTotal = enemySpawn.enemyi;
    }
 
    void OnEnable(){
        Retry.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
    }
    public void Scene1(string SceneName) {  
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);  
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth>=0)
        {
            hp.text = "HP:" + Convert.ToString(PlayerHealth);
        }
        if (PlayerHealth<=0)
        {
            Retry.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(true);
            lose.gameObject.SetActive(true);
        }
        else if (PlayerHealth>0 && enemyTotal==0)
        {
            Retry.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(true);
            win.gameObject.SetActive(true);
        }
        

    }
}
