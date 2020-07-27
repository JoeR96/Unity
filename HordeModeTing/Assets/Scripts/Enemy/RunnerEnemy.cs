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
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        _currentSpeed = _baseSpeed;
    }

    private void Update()
    {
        transform.LookAt(Player);
    
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, _currentSpeed * Time.deltaTime);
        SpeedUp();
        //if(_distance >= 2)
        //{
        //    Return();
        //}


    }   

    private void SpeedUp()
    {
        if (_currentSpeed < _maxSpeed)
        {
            _currentSpeed += 500 * Time.deltaTime;
        }

    }

}
