using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{

    [SerializeField] private Camera PlayerCamera;

    private GameObject CurrentPlacingTower;

    //public GameObject PlacedTower;

    Vector3 inpp;

    public Material TG;
    public Material TR;

    public TurretData TurretData1;
    public TurretData TurretData2;
    public TurretData TurretData3;

    //The Turret to build
    public TurretData selectedTurretData;
    public Text moneyText;
    public Animator moneyAnimator;

    public Boolean isUpgrated;
    public int money = 200;

    gameData gData;
    string saveFilePath;

    float timer = 0;    
    int imcheck =0;

    // Start is called before the first frame update
    //void Start()
    //{
    //    money = 200;
    //}

    void ChangeMoney(int change = 0)
    {
        money += change;
        moneyText.text = "$" + money;
    }

    private void Start()
    {
        gData = new gameData();
        saveFilePath = Application.persistentDataPath + "/gData.json";
        string loadgData = File.ReadAllText(saveFilePath);
        gData = JsonUtility.FromJson<gameData>(loadgData);
        

    }
    // Update is called once per frame
    void Update()
    {
        //UpgradeLookat upgradeLookat = FindFirstObjectByType<UpgradeLookat>();
        //money = upgradeLookat.money;
        if (gData.imoney == 1)
        {
            money = 99999999;
        }

        timer += Time.deltaTime;
        
        while (timer > 0.5 && gData.infinite == 1 && imcheck==0) //Spawn Enemy
        {
            money = 700;
            imcheck = 1;
        }
        
        moneyText.text = "$" + money;
        if (CurrentPlacingTower != null)
        {
            
            Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(camray.origin, camray.direction * 10, Color.yellow);
            if (Physics.Raycast(camray, out RaycastHit hitInfo, 100f))
            {
                //Vector3 inp = hitInfo.point;
                //inpp = new Vector3(Convert.ToInt32(hitInfo.point[0]),Convert.ToInt32(hitInfo.point[1]),Convert.ToInt32(hitInfo.point[2]));
                inpp = new Vector3(Convert.ToInt32(hitInfo.point[0]),hitInfo.point[1]+0.0001f,Convert.ToInt32(hitInfo.point[2]));

                CurrentPlacingTower.transform.position = inpp;
                /*
                if (Physics.Raycast(camray, out hitInfo, 100.0f, LayerMask.GetMask("Map")))
                {
                    CurrentPlacingTower.GetComponent<MeshRenderer> ().material = TG;
                    Debug.Log("g");
                }
                if (Physics.Raycast(camray, out hitInfo, 100.0f, LayerMask.GetMask("path")))
                {
                    Destroy(CurrentPlacingTower.GetComponent<MeshRenderer> ().material);
                    CurrentPlacingTower.GetComponent<MeshRenderer> ().material = TR;
                    Debug.Log("r");
                }
                */
            }

            if (Input.GetMouseButtonDown(0) && 
                !Physics.Raycast(CurrentPlacingTower.transform.position, CurrentPlacingTower.transform.up*-1.0f , out RaycastHit hit, 3f, LayerMask.GetMask("path")) && 
                !Physics.Raycast(CurrentPlacingTower.transform.position, CurrentPlacingTower.transform.up , out RaycastHit hit2, 3f, LayerMask.GetMask("Ignore Raycast")) && 
                !Physics.Raycast(CurrentPlacingTower.transform.position, CurrentPlacingTower.transform.up*1.0f , out RaycastHit hit3, 3f, LayerMask.GetMask("barrier")) && 
                !Physics.Raycast(CurrentPlacingTower.transform.position, CurrentPlacingTower.transform.up*-1.0f , out RaycastHit hit4, 3f, LayerMask.GetMask("barrier")) && 
                !(EventSystem.current.IsPointerOverGameObject()))
            {
                //Destroy(CurrentPlacingTower);
                //CurrentPlacingTower = null;
                Vector3 inppp = inpp;
                inppp[1] = 0.0f; //turret height
                
                
                if (selectedTurretData != null)
                    {
                        // Able to build turret
                        if (money >= selectedTurretData.cost)
                        {
                            ChangeMoney(-selectedTurretData.cost);
                            isUpgrated = false;
                            Instantiate(selectedTurretData.turretPrefab, inppp, Quaternion.identity);
                        }
                        else
                        {
                            //NoFund
                            moneyAnimator.SetTrigger("NoFund");
                        }
                    }
                    /*
                    else if (platform2.turretGo != null)
                    {
                        //Upgrade
                    }
                    */
            }
        }
        /*
        if (EventSystem. current. IsPointerOverGameObject())
        {
            Debug. Log("Its over UI elements");
        }
        */
        
    }

    public void UpgrateTurret()
    {
        
    }

    public void SetTower(GameObject tower)
    {
        CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
    }
    public void unablePlaceTower(bool isOn)
    {
        if (isOn)
        {

        }
        else
        {
            Debug.Log("disable");
            Destroy(CurrentPlacingTower);
            Destroy(GameObject.Find("turretPos(Clone)"));
            CurrentPlacingTower = null;
        }
        
    }

    public void OnTurretType(string type)
    {
        
        if (type == "1")
        {
            selectedTurretData = TurretData1;
        }
        if (type == "2")
        {
            selectedTurretData = TurretData2;
        }
        if (type == "3")
        {
            selectedTurretData = TurretData3;
        }
        
        else
        {
            //selectedTurretData = null;
        }
    }

}
