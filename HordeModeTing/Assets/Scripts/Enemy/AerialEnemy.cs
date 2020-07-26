using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialEnemy : BaseEnemy
{
    public AerialEnemy()
    {
        Type = PoolObjectType.AERIAL;
        CurrentHealth = 0;
        MaxHealth = 80;
        EnemyItem = null;
        Player = null;
    }
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //Replace Start with OnEnable due to ObjectPooling
    private void OnEnable()
    {
        StartCoroutine(Fire(Type));
    }

    private void Update()
    {
        transform.LookAt(Player);
    }

    private void FireBullet(PoolObjectType Type)
    {
        GameObject toSpawn = PoolManager.instance.GetPoolObject(Type);
    }

    private IEnumerator Fire(PoolObjectType Type)
    {
        GameObject toSpawn = PoolManager.instance.GetPoolObject(Type);
        yield return new WaitForSeconds(2);
    }
}
