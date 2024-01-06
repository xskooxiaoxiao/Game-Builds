using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLookat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = GameObject.Find("PlayerCamera").transform.position;
        Vector3 oppositePosition = transform.position + (transform.position - playerPosition);
        transform.LookAt(oppositePosition);
    }
}
