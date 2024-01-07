using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Windows;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.Playables;

public class UpgradeLookat : MonoBehaviour
{
    public TurretData TurretData1;
    public TurretData TurretData2;
    public TurretData TurretData3;

    public Boolean isUpgrated;

    public Text moneyText;
    public Animator moneyAnimator;
    public int money;

    TowerPlacement towerPlacement;
    void Awake()
    {
        towerPlacement = GameObject.Find("PlayerCamera").GetComponent<TowerPlacement>();
    }

    // Start is called before the first frame updateaw
    void Start()
    {
        money = towerPlacement.money;
        //TowerPlacement towerPlacement = FindFirstObjectByType<TowerPlacement>();
        moneyText = GameObject.Find("Canvas/Money").GetComponent<Text>();
        moneyAnimator = GameObject.Find("Canvas/Money").GetComponent<Animator>();


        /*
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        */
        GameObject[] canvasObjects = GameObject.FindGameObjectsWithTag("CanvasU");
        foreach (GameObject canvasObject in canvasObjects)
        {
            for (int i = 0; i < canvasObject.transform.childCount; i++)
            {
                canvasObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        TowerPlacement towerPlacement = FindFirstObjectByType<TowerPlacement>();
        //money = towerPlacement.money;
        TurretData1 = towerPlacement.TurretData1;
        TurretData2 = towerPlacement.TurretData2;
        TurretData3 = towerPlacement.TurretData3;

        Vector3 playerPosition = GameObject.Find("PlayerCamera").transform.position;
        Vector3 oppositePosition = transform.position + (transform.position - playerPosition);
        transform.LookAt(oppositePosition);

        Debug.Log("Money: " + towerPlacement.money);
    }

    public void UpgradeButtonVis(bool isOn)
    {
        GameObject[] canvasObjects = GameObject.FindGameObjectsWithTag("CanvasU");
        if (isOn)
        {
            foreach (GameObject canvasObject in canvasObjects)
            {
                for (int i = 0; i < canvasObject.transform.childCount; i++)
                {
                    canvasObject.transform.GetChild(i).gameObject.SetActive(true);
                }
                
            }
        }
        else
        {
            foreach (GameObject canvasObject in canvasObjects)
            {
                for (int i = 0; i < canvasObject.transform.childCount; i++)
                {
                    canvasObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
    public void UpgrateTurret1()
    {
        if (towerPlacement.money >= TurretData1.costUpgrade)
        {
            if (isUpgrated == false)
            {
                isUpgrated = true;
                towerPlacement.money -= TurretData1.costUpgrade;
                Vector3 currentPosition = transform.position;
                currentPosition.y -= 1.29f;
                Destroy(transform.root.gameObject);
                Instantiate(TurretData1.turretUpgradePrefab, currentPosition, Quaternion.identity);
            }
            else
            {
                return;
            }
        }
        else
        {
            moneyAnimator.SetTrigger("NoFund");
        }
              
    }

    public void UpgrateTurret2()
    {
        if (towerPlacement.money >= TurretData2.costUpgrade)
        {
            if (isUpgrated == false)
            {
                isUpgrated = true;
                towerPlacement.money -= TurretData2.costUpgrade;
                Vector3 currentPosition = transform.position;
                currentPosition.y -= 1.29f;
                Destroy(transform.root.gameObject);
                Instantiate(TurretData2.turretUpgradePrefab, currentPosition, Quaternion.identity);
            }
            else
            {
                return;
            }
        }
        else
        {
            moneyAnimator.SetTrigger("NoFund");
        }
    }

    public void UpgrateTurret3()
    {
        if (towerPlacement.money >= TurretData3.costUpgrade)
        {
            if (isUpgrated == false)
            {
                isUpgrated = true;
                towerPlacement.money -= TurretData3.costUpgrade;
                Vector3 currentPosition = transform.position;
                currentPosition.y -= 1.29f;
                Destroy(transform.root.gameObject);
                Instantiate(TurretData3.turretUpgradePrefab, currentPosition, Quaternion.identity);
            }
            else
            {
                return;
            }
        }
        else
        {
            moneyAnimator.SetTrigger("NoFund");
        }
    }

}   