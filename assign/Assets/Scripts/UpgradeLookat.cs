using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Windows;

public class UpgradeLookat : MonoBehaviour
{
    public TurretData TurretData1;
    public TurretData TurretData2;
    public TurretData TurretData3;

    public Boolean isUpgrated;

    // Start is called before the first frame update
    void Start()
    {
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
        Vector3 playerPosition = GameObject.Find("PlayerCamera").transform.position;
        Vector3 oppositePosition = transform.position + (transform.position - playerPosition);
        transform.LookAt(oppositePosition);
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
        if(isUpgrated == false)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y -= 1.29f;
            isUpgrated = true;
            Destroy(transform.root.gameObject);
            Instantiate(TurretData1.turretUpgradePrefab, currentPosition, Quaternion.identity);
        }
        else
        {
            return;
        }
    }

    public void UpgrateTurret2()
    {
        if (isUpgrated == false)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y -= 1.29f;
            isUpgrated = true;
            Destroy(transform.root.gameObject);
            Instantiate(TurretData2.turretUpgradePrefab, currentPosition, Quaternion.identity);
        }
        else
        {
            return;
        }
    }

    public void UpgrateTurret3()
    {
        if (isUpgrated == false)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y -= 1.29f;
            isUpgrated = true;
            Destroy(transform.root.gameObject);
            Instantiate(TurretData3.turretUpgradePrefab, currentPosition, Quaternion.identity);
        }
        else
        {
            return;
        }
    }

}   