using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretPosPlane : MonoBehaviour
{
    public Material TG;
    public Material TR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.up*-1.0f , out RaycastHit hit, 3f, LayerMask.GetMask("Map")))
        {
            this.gameObject.GetComponent<MeshRenderer> ().material = TG;
            //Debug.Log("g");
        }
        if (Physics.Raycast(transform.position, transform.up*-1.0f , out RaycastHit hit2, 3f, LayerMask.GetMask("path")) || Physics.Raycast(transform.position, transform.up , out RaycastHit hit3, 3f, LayerMask.GetMask("Ignore Raycast")))
        {
            this.gameObject.GetComponent<MeshRenderer> ().material = TR;
            //Debug.Log("r");
        }

    }
    void OnTriggerEnter(Collider col)
    {
        /*
        if (col.tag == "path")
        {
            this.gameObject.GetComponent<MeshRenderer> ().material = TR;
            Debug.Log("r");
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer> ().material = TG;
            Debug.Log("g");
        }
        */
    }

}
