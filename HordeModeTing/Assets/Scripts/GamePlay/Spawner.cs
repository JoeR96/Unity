using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public List<Transform> GroundSpawnpoints = new List<Transform>();
    [SerializeField]
    public List<Transform> AerialSpawnPoints = new List<Transform>();

    int amountToSpawn;

    public void Spawn(PoolObjectType type, int amountToSpawn, List<Transform> spawns)
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            GameObject toSpawn = PoolManager.instance.GetPoolObject(type);
            toSpawn.transform.position = spawns[i].position;
            toSpawn.gameObject.SetActive(true);
        }
    }
    //private void SpawnRunner(PoolObjectType type)
    //{
    //    for (int i = 0; i < amountToSpawn; i++)
    //    {
    //        GameObject runnerObj = PoolManager.instance.GetPoolObject(type);
    //        runnerObj.transform.position = RunnerSpawnpoints[i].position;
    //        runnerObj.gameObject.SetActive(true);
    //    }
        
    //}

}
