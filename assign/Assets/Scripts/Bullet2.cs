using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public int damage = 25;
    //public float speed = 5;

    private Transform target;

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    void Update()
    {
        /*
        if (target == null)
        {
            Die();
            return;
        }
*/
        //transform.LookAt(target.position);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
