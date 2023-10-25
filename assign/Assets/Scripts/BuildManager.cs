using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    public TurretData TurretData;

    //The Turret to build
    public TurretData selectedTurretData;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                //Turret Build
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Map"));
                if (isCollider)
                {
                    platform platform2 = hit.collider.GetComponent<platform>();//Detect Grid
                    if(platform2.turretGo == null)
                    {
                        // Able to build turret
                        platform2.BuildTurret(selectedTurretData.turretPrefab);
                    }
                    else
                    {
                        //Upgrade
                    }
                }
            }
        }
    }

    public void OnTurretSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = TurretData;
        }
        else
        {
            selectedTurretData = null;
        }
    }
}
    