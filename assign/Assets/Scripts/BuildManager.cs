using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public TurretData TurretData;

    //The Turret to build
    public TurretData selectedTurretData;
    
    public void OnTurretSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = TurretData;
        }
    }
}
    