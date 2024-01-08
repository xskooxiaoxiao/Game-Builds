using UnityEngine;
using System.Collections;
using System;
using TMPro;
using System.IO;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;


    public GameObject e1; //Enemy type 1
    public GameObject e2; //Enemy type 2
    public GameObject e3; //Enemy type 3
    public GameObject e4; //Enemy type 4

    public float startcountdown = 3.0f;
    private int start=0;


    public Wave[] waves;
    public int currentWaveIndex = 0;
    
    public int DeadCount = 0;

    public bool gameEnd = false;

    private bool readyToCountDown;

    gameData gData;
    string saveFilePath;

    float timer=0;
    float delay = 1.0f;
    int enemyi = 30;
    int s1=10;
    int s2=10;
    int s3=10;
    int s4=1;


    
    private void Start()
    {
        gData = new gameData();
        saveFilePath = Application.persistentDataPath + "/gData.json";
        string loadgData = File.ReadAllText(saveFilePath);
        gData = JsonUtility.FromJson<gameData>(loadgData);
        
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
            
        }
    }
    private void Update()
    {
        if (start == 0)
        {
            startcountdown -= Time.deltaTime;
            if (startcountdown < 0.0f)
            {
                start = 1;
            }
            
        }
        else if (start == 1 && gData.normal == 1)
        {
            if (currentWaveIndex >= waves.Length)
        {
            //Debug.Log("You survived every wave!");
            gameEnd = true;
            return;
        }

        if (readyToCountDown == true)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            readyToCountDown = false;

            countdown = waves[currentWaveIndex].timeToNextWave;

            StartCoroutine(SpawnWave());
        }

        if (DeadCount == waves[currentWaveIndex].enemies.Length )
        {
            readyToCountDown = true;
            DeadCount = 0;
            currentWaveIndex++;
            
        }
        }


        else if (start == 1 && (gData.infinite == 1 || gData.imoney == 1))
        {
            timer += Time.deltaTime;
        
       
            while (timer > delay) //Spawn Enemy
            {
                if (s1 > 0)
                {
                    GameObject newObject = Instantiate(e1);
                    s1--;
                }
                else if (s2 > 0)
                {
                    GameObject newObject = Instantiate(e2);
                    s2--;
                }
                else if (s3 > 0)
                {
                    GameObject newObject = Instantiate(e3);
                    s3--;
                }
                else if (s4 > 0)
                {
                    GameObject newObject = Instantiate(e4);
                    s1=10;
                    s2=10;
                    s3=10;
                }
                
                timer = 0;
            }
        }

        
        
    }
    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                if (waves[currentWaveIndex].enemies[i] == "1")
                {
                    GameObject newObject = Instantiate(e1);
                }
                else if (waves[currentWaveIndex].enemies[i] == "2")
                {
                    GameObject newObject = Instantiate(e2);
                }
                else if (waves[currentWaveIndex].enemies[i] == "3")
                {
                    GameObject newObject = Instantiate(e3);
                }
                else if (waves[currentWaveIndex].enemies[i] == "4")
                {
                    GameObject newObject = Instantiate(e4);
                }


                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
            
        }
    }
}

[System.Serializable]
public class Wave
{
    
    public string[] enemies;
    //public Enemy[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;

    [HideInInspector] public int enemiesLeft;
}