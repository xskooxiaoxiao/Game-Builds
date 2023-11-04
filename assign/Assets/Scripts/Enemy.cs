using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 150;

    PlayerState playerState;

    void Awake()
    {
        playerState = GameObject.Find("PlayerState").GetComponent<PlayerState>();
    }

    public void TakeDamage(int damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        playerState.enemyTotal -= 1;
    }
}
