using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVis : MonoBehaviour
{
    
    GameObject originalGameObject;

    // Start is called before the first frame update
    void Start()
    {
        originalGameObject = GameObject.Find("PlatformMap");
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < originalGameObject.transform.childCount; i++)
            {
                GameObject child = originalGameObject.transform.GetChild(i).gameObject;
                if (child.GetComponent<platform>().visible==0)
                {
                    child.SetActive(true);
                }
            }
        }
        */
        
    }

    public void OnTurretVisible(bool isOn)
    {   
        GameObject child;
        if (isOn)
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                child = this.gameObject.transform.GetChild(i).gameObject;
                if (child.GetComponent<platform>().visible==0)
                {
                    child.SetActive(true);
                    //Debug.Log("true");
                }
            }
        }
        else
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                child = this.gameObject.transform.GetChild(i).gameObject;

                if (child.GetComponent<platform>().visible==0)
                {
                    child.SetActive(false);
                    //Debug.Log("false");
                }
            }
        }
    }
}
