using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //UI Variables
    public int EnemyCounter;
    private int AmountToSpawn = 1;
    [SerializeField]
    private bool _enemiesAlive;

    Spawner spawn;
    private void Awake()
    {
        spawn = GetComponent<Spawner>();
        StartCoroutine("WaveSequence");
    }

    private void Update()
    {
        if (EnemyCounter == 0)
            _enemiesAlive = false;

    }

    //Idle State
    #region Waves
    private IEnumerator WaveSequence()
    {
        WaveOne();
        while (_enemiesAlive)
            yield return null;
        WaveTwo();
        while (_enemiesAlive)
            yield return null;
        WaveThree();
        while (_enemiesAlive)
            yield return null;
        WaveFour();

    }
    //Wave 1
    //Pistol Kill "regular enemy" drops rifle
    private void WaveOne()
    {
        Debug.Log("One");
        spawn.Spawn(PoolObjectType.MELEE, AmountToSpawn, spawn.GroundSpawnpoints);
        EnemyCounter += AmountToSpawn;
        _enemiesAlive = true;
    }
    //Wave 2
    //Runner wave - drops Shotgun 
    private void WaveTwo()
    {
        Debug.Log("Two");
        AmountToSpawn = 1;
        spawn.Spawn(PoolObjectType.RUNNER, AmountToSpawn, spawn.GroundSpawnpoints);
        EnemyCounter += AmountToSpawn;
        _enemiesAlive = true;
    }
    //Wave 3
    //Juggernaut miniboss - introduce player to weak spots
    //Drops sniper rifle
    private void WaveThree()
    {
        AmountToSpawn = 1;
        spawn.Spawn(PoolObjectType.JUGGERNAUT, AmountToSpawn, spawn.GroundSpawnpoints);
        EnemyCounter += AmountToSpawn;
        _enemiesAlive = true;
    }
    //Wave 4
    //Aerial wave - use sniper to kill
    private void WaveFour()
    {
        AmountToSpawn = 1;
        spawn.Spawn(PoolObjectType.AERIAL, AmountToSpawn, spawn.AerialSpawnPoints);
        EnemyCounter += AmountToSpawn;
        _enemiesAlive = true;
    }
    //Wave 5
    //Introduction to Horde Mode
    private void WaveFive()
    {
        //Random wave code -- later
    }
    #endregion
}
