using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialEnemy : BaseEnemy
{
    public AerialEnemy()
    {
        Type = PoolObjectType.AERIAL;
        EnemyItem = PoolObjectType.BULLET;        
        CurrentHealth = 0;
        MaxHealth = 80;
        Player = null;
    }
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    //Replace Start with OnEnable due to ObjectPooling
    private void OnEnable()
    {
        
    }

    private void Update()
    {
        transform.LookAt(Player);
        FireBullet(EnemyItem);
    }

    private void FireBullet(PoolObjectType Type)
    {
        GameObject toSpawn = PoolManager.instance.GetPoolObject(Type);
        toSpawn.transform.position = transform.position;
        toSpawn.transform.Rotate(115, 0, 0);
    }

    private void Fire(PoolObjectType Type)
    {
        GameObject toSpawn = PoolManager.instance.GetPoolObject(Type);
    }
}
