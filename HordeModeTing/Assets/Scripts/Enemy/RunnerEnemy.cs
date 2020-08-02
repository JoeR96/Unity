using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : BaseEnemy
{
    public RunnerEnemy()
    {
        Type = PoolObjectType.RUNNER;
        MaxHealth = 55;
        _baseSpeed = 0.5f;
        _maxSpeed = 10f;
        Damage = 25f;
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        _currentSpeed = _baseSpeed;
    }

    private void Update()
    {
        transform.LookAt(Player);
        var dist = Vector3.Distance(transform.position, Player.position);
        if(dist > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, _currentSpeed * Time.deltaTime);
            SpeedUp();
        }
    }

    protected override void DamageEnemy(float damage)
    {
        base.DamageEnemy(Damage);
    }
    protected override void OnTriggerEnter(Collider other)
    {
        DamageEnemy(Damage);
    }

    private void SpeedUp()
    {
        if (_currentSpeed < _maxSpeed)
        {
            _currentSpeed += 500 * Time.deltaTime;
        }

    }

}
