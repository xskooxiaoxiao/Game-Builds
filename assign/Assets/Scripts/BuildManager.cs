using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public TurretData TurretData;

    //The Turret to build
    public TurretData selectedTurretData;
    public Text moneyText;
    public Animator moneyAnimator;
    private int money = 200;

    void ChangeMoney(int change = 0)
    {
        money += change;
        moneyText.text = "$" + money;
    }
    
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
                    if (selectedTurretData != null && platform2.turretGo == null)
                    {
                        // Able to build turret
                        if (money >= selectedTurretData.cost)
                        {
                            ChangeMoney(-selectedTurretData.cost);
                            platform2.BuildTurret(selectedTurretData.turretPrefab);
                        }
                        else
                        {
                            //NoFund
                            moneyAnimator.SetTrigger("NoFund");
                        }
                    }
                    else if (platform2.turretGo != null)
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
    