using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 150;

    public int earn = 20;

    PlayerState playerState;

    BuildManager buildManager;

    void Awake()
    {
        playerState = GameObject.Find("PlayerState").GetComponent<PlayerState>();
        buildManager = GameObject.Find("GameControl").GetComponent<BuildManager>();
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
        buildManager.money += earn;
    }
}
