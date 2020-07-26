using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : BaseEnemy
{
    public BossEnemy()
    {
        Type = PoolObjectType.BOSS;
        CurrentHealth = 0;
        MaxHealth = 80;
        Player = null;
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
