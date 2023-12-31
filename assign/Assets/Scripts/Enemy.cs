using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 150;

    public int earn = 20;

    PlayerState playerState;

    BuildManager buildManager;
    TowerPlacement towerPlacement;
    WaveSpawner waveSpawner;

    public ParticleSystem EnemyDeath;

    void Awake()
    {
        playerState = GameObject.Find("PlayerState").GetComponent<PlayerState>();
        buildManager = GameObject.Find("GameControl").GetComponent<BuildManager>();
        towerPlacement = GameObject.Find("PlayerCamera").GetComponent<TowerPlacement>();
        waveSpawner = GameObject.Find("GameControl").GetComponent<WaveSpawner>();
    }

    public void TakeDamage(int damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        //Debug.Log(hp);
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(EnemyDeath, transform.position, transform.rotation);
        Destroy(this.gameObject);
        waveSpawner.DeadCount += 1;
        playerState.enemyTotal -= 1;
        buildManager.money += earn;
        towerPlacement.money += earn;
        
    }
}
