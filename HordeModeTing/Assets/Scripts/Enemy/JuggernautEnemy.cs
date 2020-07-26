using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautEnemy : BaseEnemy
{
    public JuggernautEnemy()
    {
        Type = PoolObjectType.JUGGERNAUT;
        CurrentHealth = 0;
        MaxHealth = 80;
        Player = null;
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
