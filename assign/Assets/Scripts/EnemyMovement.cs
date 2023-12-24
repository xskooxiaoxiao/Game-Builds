using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 5.0f; //speed
    MapSystem mapSystem;
    //EnemySpawn enemySpawn;
    PlayerState playerState;
    WaveSpawner waveSpawner;
    
    // The target position.
    //private Transform target;
    //private Vector3 target;
    //Vector3[] target;
    //private Vector3 tarpos;
    int i=0;
    Vector3[] pin;
    int pini;
    public float enemyheight = 1f;

    public int DamagetoPlayerHealth = 1; //Damage to PlayerHealth

void Awake()
    {
        // Position the cube at the origin.
        //transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        // Create and position the cylinder. Reduce the size.
        //var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        //cylinder.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);

        // Grab cylinder values and place on the target.
        //target = cylinder.transform;
        //target.transform.position = new Vector3(0.8f, 0.0f, 0.8f);
        /*
        target = new Vector3[3];
        target[0] = new Vector3(3.8f, 0.0f, 0.8f);
        target[1] = new Vector3(1.8f, 0.0f, 1.8f);
        target[2] = new Vector3(5.8f, 0.0f, 2.8f);
        */
        
        //enemySpawn = GameObject.Find("GameControl").GetComponent<EnemySpawn>();
        playerState = GameObject.Find("PlayerState").GetComponent<PlayerState>();
        waveSpawner = GameObject.Find("GameControl").GetComponent<WaveSpawner>();

        // Create a temporary reference to the current scene.
		Scene currentScene = SceneManager.GetActiveScene ();
		// Retrieve the name of this scene.
		string sceneName = currentScene.name;
        if (sceneName == "Level1") 
		{
            transform.position = new Vector3(-18.0f,enemyheight,21.0f);
            pini = 7;
            pin = new Vector3[pini];
            pin[0] = new Vector3(-18.0f,0.0f,21.0f);
            pin[1] = new Vector3(-18.0f,0.0f,10.55f);
            pin[2] = new Vector3(-12.0f,0.0f,10.55f);
            pin[3] = new Vector3(-12.0f,0.0f,5.55f);
            pin[4] = new Vector3(2f,0.0f,5.55f);
            pin[5] = new Vector3(2f,0.0f,13.55f);
            pin[6] = new Vector3(11f,0.0f,13.55f);
            for (int j=0;j<pini;j++)
            {
            //pin[j] = mapSystem.target[j];
            pin[j][1] = enemyheight;
            
            }
		}
		else if (sceneName == "LevelR")
		{
			mapSystem = GameObject.Find("MAP").GetComponent<MapSystem>();
            pini = mapSystem.targeti;
            pin = new Vector3[pini];
            for (int j=0;j<pini;j++)
            {
                pin[j] = mapSystem.target[j];
                pin[j][1] = enemyheight;
            
            }

            transform.position = pin[0]; //enemy spawnpoint
		}


        

         //enemy spawnpoint
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        // Move our position a step closer to the target.
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, pin[i], step);
        // Face toward waypoint
        Vector3 relativePos = pin[i] - transform.position;
        transform.rotation = Quaternion.LookRotation (relativePos);


        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, pin[i]) < 0.001f)
        {
            // Swap the position of the cylinder.
            i++;
            
            if (i==pini)
            {
                i=pini-1;
            }
            
        }

        if (transform.position == pin[pini-1]) 
        {
            Destroy (gameObject);
            playerState.PlayerHealth -= DamagetoPlayerHealth;
            playerState.enemyTotal -= 1;
            Debug.Log(playerState.PlayerHealth);
            waveSpawner.DeadCount += 1;
        }
    }
}
