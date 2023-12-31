using UnityEngine;
using System.Collections;
using System;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;


    public GameObject e1; //Enemy type 1
    public GameObject e2; //Enemy type 2
    public GameObject e3; //Enemy type 3
    public GameObject e4; //Enemy type 4


    public Wave[] waves;
    public int currentWaveIndex = 0;
    
    public int DeadCount = 0;

    public bool gameEnd = false;

    private bool readyToCountDown;


    
    private void Start()
    {
        
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
            
        }
    }
    private void Update()
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