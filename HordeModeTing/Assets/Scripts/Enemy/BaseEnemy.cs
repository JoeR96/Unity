using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;
    public bool Alive = true;
    public GameObject EnemyItem;
    public PoolObjectType Type;
    public Transform Player;
    public float BaseSpeed;

    public void DamageEnemy(float damage)
    {
        if (Alive)
            CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            GameManager.instance.EnemyCounter --;
            Return();
        }
            
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {      
        CurrentHealth = MaxHealth;
    }

    private void Return()
    {
        PoolManager.instance.ReturnObject(this.gameObject, Type);
    }

    private void Update()
    {
            
    }
}
