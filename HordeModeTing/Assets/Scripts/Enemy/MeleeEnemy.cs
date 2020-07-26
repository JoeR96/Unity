using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    public MeleeEnemy()
    {
        CurrentHealth = 0;
        MaxHealth = 100;
        Type = PoolObjectType.MELEE;
        Player = null;
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
