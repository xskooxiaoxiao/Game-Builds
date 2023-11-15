using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;//Save current turret on the grid

    public int visible = 0;

    void Start()
    {
        this.gameObject.SetActive(false);
        
    }
    public void BuildTurret(GameObject turretPrefab)
    {
        turretGo = GameObject.Instantiate(turretPrefab, transform.position, Quaternion.identity);
        visible = 1;
    }

    void Update()
    {
        
        if (visible == 1)
        {
            this.gameObject.SetActive(true);
        }
        
        
    }
}
