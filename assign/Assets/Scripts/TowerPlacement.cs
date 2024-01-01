using System;
using System.Collections;
using System.Collections.Generic;
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
    public int money = 200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ChangeMoney(int change = 0)
    {
        money += change;
        moneyText.text = "$" + money;
    }

    // Update is called once per frame
    void Update()
    {

        if (CurrentPlacingTower != null)
        {
            moneyText.text = "$" + money;
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

    /*
    public void OnTurretSelected(bool isOn)
    {
        if (isOn)
        {
            
            
            //selectedTurretData = TurretData;
            
            
        }
        
        else
        {
            selectedTurretData = null;
        }
        
    }
    */
    
}
