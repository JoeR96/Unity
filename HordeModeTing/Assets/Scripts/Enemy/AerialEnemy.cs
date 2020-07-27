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
        FireBullet(EnemyItem);
    }

    //Replace Start with OnEnable due to ObjectPooling
    private void OnEnable()
    {
        
    }

    private void Update()
    {
        transform.LookAt(Player);
    }

    private void FireBullet(PoolObjectType Type)
    {
        GameObject toSpawn = PoolManager.instance.GetPoolObject(Type);
        toSpawn.transform.position = transform.position;
        toSpawn.transform.Rotate(115, 0, 0);
    }

    private IEnumerator Fire(PoolObjectType Type)
    {
        GameObject toSpawn = PoolManager.instance.GetPoolObject(Type);
        yield return new WaitForSeconds(2);
    }
}
