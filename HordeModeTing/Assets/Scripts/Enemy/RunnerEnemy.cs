using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : BaseEnemy
{
    public RunnerEnemy()
    {
        Type = PoolObjectType.RUNNER;
        CurrentHealth = 0;
        MaxHealth = 100;
        BaseSpeed = 1f;
    }

    private void Update()
    {
        transform.LookAt(Player);
        transform.position = Vector3.MoveTowards(transform.position, Player.position, BaseSpeed * Time.deltaTime);
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
