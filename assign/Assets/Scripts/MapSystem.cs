using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class MapSystem : MonoBehaviour
{
    public Vector3[] target; //pinpoint position
    GameObject[] pinCylinder; //pinpoint reference
    GameObject[] pave; //path
    public GameObject pathcube;
    public GameObject walll;
    GameObject[] wall; //wall
    public int targeti = 4; //number of pinpoint
    public float mapscale = 26.0f;// scale of the map
    mapData mData;
    string saveFilePath;
    

/*
    public GameObject objectToSpawn;
    public int enemyi = 2; //Enemy amount
    public float delay = 2; //Enemy spawn delay
    float timer=0;
*/


    // Start is called before the first frame update
    void Awake()
    {
        //receive parameter from RandomParameter.scene
        mData = new mapData();
        saveFilePath = Application.persistentDataPath + "/mData.json";
        string loadmData = File.ReadAllText(saveFilePath);
        mData = JsonUtility.FromJson<mapData>(loadmData);
        targeti = mData.wa;
        mapscale = mData.ma;


        target = new Vector3[targeti];
        pinCylinder = new GameObject[targeti];
        pave = new GameObject[targeti-1];
        wall = new GameObject[4];
        /*
        target[0] = new Vector3(Random.Range(2.0f, 24.0f), 0.0f, 0.0f);
        target[1] = new Vector3(1.8f, 0.0f, 1.8f);
        target[2] = new Vector3(5.8f, 0.0f, 2.8f);
        target[3] = new Vector3(6.8f, 0.0f, 2.8f);
        */

        //SpawnWaypoint
        spawnpin();

/*
        for (int i=0;i<targeti;i++)//pin cylinder spawn
        {
            pinCylinder[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            pinCylinder[i].transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);
            pinCylinder[i].transform.position = target[i];
        }
*/
        
        for (int k=0;k<targeti-1;k++)//path spawning
        {
            pave[k] = GameObject.Instantiate(pathcube);
            pave[k].GetComponent<Renderer>().material.color = new Color(171.0f/255.0f,100.0f/255.0f,46.0f/255.0f,1.0f);
            if (target[k][0] == target[k+1][0])
            {
                float pscale = Math.Abs(target[k][2]-target[k+1][2]) ;
                pave[k].transform.localScale = new Vector3(1.0f, 1.0f, pscale+1);
                Vector3 ppos = target[k];
                ppos[2] = Math.Abs(target[k][2]+target[k+1][2])/2;
                ppos[1] = -0.4f;
                pave[k].transform.position = ppos;

            }
            else if (target[k][2] == target[k+1][2])
            {
                float pscale = Math.Abs(target[k][0]-target[k+1][0]) ;
                pave[k].transform.localScale = new Vector3(pscale+1, 1.0f, 1.0f);
                Vector3 ppos = target[k];
                ppos[0] = Math.Abs(target[k][0]+target[k+1][0])/2;
                ppos[1] = -0.4f;
                pave[k].transform.position = ppos;

            }
            
        }

        for (int m=0; m<4; m++) //Spawn Wall
        {
            //wall[m] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall[m] = GameObject.Instantiate(walll);
        }

        wall[0].transform.localScale = new Vector3(mapscale-1, 1.0f, 1.0f);
        wall[1].transform.localScale = new Vector3(mapscale-1, 1.0f, 1.0f);
        wall[2].transform.localScale = new Vector3(1.0f, 1.0f, mapscale-1);
        wall[3].transform.localScale = new Vector3(1.0f, 1.0f, mapscale-1);

        wall[0].transform.position = new Vector3(mapscale/2, 0.51f, 0.0f);
        wall[1].transform.position = new Vector3(mapscale/2, 0.51f, mapscale);
        wall[2].transform.position = new Vector3(0.0f, 0.51f, mapscale/2);
        wall[3].transform.position = new Vector3(mapscale, 0.51f, mapscale/2);
        //

        
    }

    void spawnpin() // Spawn Waypoint
    {
        int mapscalei = Convert.ToInt32(mapscale);
        
        int p0 = Random.Range(1,5);
        int lastp = p0;
        //p0p1
        if (p0==1)
        {
            target[0] = new Vector3(Random.Range(1, mapscalei-1), 0.0f, 0.0f);
            up(1);
        }
        else if (p0==2)
        {
            target[0] = new Vector3(Random.Range(1, mapscalei-1), 0.0f, mapscale);
            down(1);
        }
        else if (p0==3)
        {
            target[0] = new Vector3(mapscale, 0.0f, Random.Range(1, mapscalei-1));
            left(1);
        }
        else if (p0==4)
        {
            target[0] = new Vector3(0.0f, 0.0f, Random.Range(1, mapscalei-1));
            right(1);
        }

        //p2-pfinal(targeti-1)
        for (int j=2;j<targeti;j++)
        {
            Debug.Log(targeti);
            int thisp = Random.Range(1,4);
            if (lastp == 1)
            {
                if (thisp == 1)
                {
                    up(j);
                } 
                else if (thisp == 2)
                {
                    left(j);
                }
                else if (thisp == 3)
                {
                    right(j);
                }
                
            }
            else if (lastp == 2)
            {
                if (thisp == 1)
                {
                    down(j);
                } 
                else if (thisp == 2)
                {
                    left(j);
                }
                else if (thisp == 3)
                {
                    right(j);
                }
            }
            else if (lastp == 3)
            {
                if (thisp == 1)
                {
                    up(j);
                } 
                else if (thisp == 2)
                {
                    down(j);
                }
                else if (thisp == 3)
                {
                    left(j);
                }
            }
            else if (lastp == 4)
            {
                if (thisp == 1)
                {
                    up(j);
                } 
                else if (thisp == 2)
                {
                    down(j);
                }
                else if (thisp == 3)
                {
                    right(j);
                }
            }

            
        }
        
        
        void up(int a)
        {
            target[a] = target[a-1];
            if (a == targeti-1)
            {
                target[a][2] = mapscale;
                Debug.Log("end");
            }
            else if (target[a][2] == mapscale-1.0f)
            {
                target[a][2] = mapscale-1.0f;
            }
            else
            {
                target[a][2] = Random.Range(Convert.ToInt32(target[a][2]+1),mapscalei-1);
            }
            
            lastp = 1;
        }
        void down(int a)
        {
            target[a] = target[a-1];
            if (a == targeti-1)
            {
                target[a][2] = 0.0f;
                Debug.Log("end");
            }
            else if (target[a][2] == 1.0f)
            {
                target[a][2] = 1.0f;
            }
            else
            {
                target[a][2] = Random.Range(Convert.ToInt32(target[a][2]-1),1);
            }

            lastp = 2;
        }
        void left(int a)
        {
            target[a] = target[a-1];
            if (a == targeti-1)
            {
                target[a][0] = 0.0f;
                Debug.Log("end");
            }
            else if (target[a][0] == 1.0f)
            {
                target[a][0] = 1.0f;
            }
            else
            {
                target[a][0] = Random.Range(Convert.ToInt32(target[a][0]-1),1);
            }
            
            lastp = 3;
        }
        void right(int a)
        {
            target[a] = target[a-1];
            if (a == targeti-1)
            {
                target[a][0] = mapscale;
                Debug.Log("end");
            }
            else if (target[a][0] == mapscale-1.0f)
            {
                target[a][0] = mapscale-1.0f;
            }
            else
            {
                target[a][0] = Random.Range(Convert.ToInt32(target[a][0]+1),mapscalei-1);
            }
            
            lastp = 4;
        }
    }




    void SpawnOject() //Spawn Enemy
    {
        //GameObject newObject = Instantiate(objectToSpawn);
    }

    
    void Start()
    {
       //SpawnOject();
       
    }

    // Update is called once per frame
    void Update()
    {
        /*
        timer += Time.deltaTime;
       
        while (timer > delay && enemyi>0) //Spawn Enemy
        {
            SpawnOject();
            enemyi--;
            timer = 0;
        }
    */


    }
}
