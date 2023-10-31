using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject objectToSpawn;

    public int enemyi = 2; //Enemy amount
    public float delay = 2; //Enemy spawn delay
    float timer=0;
    //float timer2=0;

    public int PlayerHealth = 10;

    //MapSystem mapSystem2;

    //Vector3 endpoint;

    void SpawnOject() //Spawn Enemy
    {
        GameObject newObject = Instantiate(objectToSpawn);
    }

void Awake()
    {
        //mapSystem2 = GameObject.Find("Plane").GetComponent<MapSystem>();
        //endpoint = mapSystem.target[mapSystem.targeti-1];
    }


    // Start is called before the first frame update*********************
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
       
        while (timer > delay && enemyi>0) //Spawn Enemy
        {
            SpawnOject();
            enemyi--;
            timer = 0;
        }

        
        
        
    }
}
