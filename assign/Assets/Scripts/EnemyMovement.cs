using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 5.0f; //speed
    //MapSystem mapSystem;
    EnemySpawn enemySpawn;
    
    // The target position.
    //private Transform target;
    //private Vector3 target;
    //Vector3[] target;
    //private Vector3 tarpos;
    int i=0;
    Vector3[] pin;
    int pini;
    float enemyheight = -2.3f;

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
        
        //mapSystem = GameObject.Find("Plane").GetComponent<MapSystem>();
        //enemySpawn = GameObject.Find("GameControl").GetComponent<EnemySpawn>();
        transform.position = new Vector3(-18.0f,enemyheight,21.0f);
        pini = 7;
        pin = new Vector3[pini];
        pin[0] = new Vector3(-18.0f,0.0f,21.0f);
        pin[1] = new Vector3(-18.0f,0.0f,10.5f);
        pin[2] = new Vector3(-12.3f,0.0f,10.5f);
        pin[3] = new Vector3(-12.3f,0.0f,6.8f);
        pin[4] = new Vector3(2.3f,0.0f,6.8f);
        pin[5] = new Vector3(2.3f,0.0f,13.4f);
        pin[6] = new Vector3(10.6f,0.0f,13.4f);
        for (int j=0;j<pini;j++)
        {
            //pin[j] = mapSystem.target[j];
            pin[j][1] = enemyheight;
            
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
            enemySpawn.PlayerHealth -= DamagetoPlayerHealth;
            Debug.Log(enemySpawn.PlayerHealth);
        }
    }
}
