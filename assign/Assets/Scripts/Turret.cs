using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour{

    public List<GameObject> enemys = new List<GameObject>();

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Remove(col.gameObject);
        }
    }

    public float attackRate = 1;
    private float timer = 0;
    public GameObject bulletPrefab;
    public Transform bulletPosition;
    public Transform head;

    void Start()
    {
        timer = attackRate;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (enemys.Count > 0 && timer > attackRate)
        {
            timer = 0;
            Attack();
        }
        if (enemys.Count > 0 && enemys[0] != null)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
    }

    void Attack()
    {
        if (enemys[0] == null)
        {
            UpdateEnemys();
        }
        if (enemys.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
        else
        {
            timer = attackRate;
        }
         
    }

    void UpdateEnemys()
    {
        enemys.RemoveAll(item => item == null);
    }
}
