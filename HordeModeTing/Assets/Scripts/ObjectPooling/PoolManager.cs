using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolObjectType
{
    RUNNER,
    MELEE,
    JUGGERNAUT,
    AERIAL,
    BOSS,
    BULLET
}

[Serializable]
public class PoolType
{
    public PoolObjectType type;
    public int amountToPool = 0;
    public GameObject prefabToPool;
    public GameObject poolHolder;
        
    public List<GameObject> objectPool = new List<GameObject>();
}
public class PoolManager : Singleton<PoolManager>   
{
    [SerializeField]
    List<PoolType> poolList;

    void Start()
    {
        for (int i = 0; i < poolList.Count; i++)
        {
            FillPool(poolList[i]);
        }
    }

    void FillPool(PoolType poolType)
    {
        for (int i = 0; i < poolType.amountToPool; i++)
        {
            GameObject objToPool = null;
            objToPool = Instantiate(poolType.prefabToPool, poolType.poolHolder.transform);
            objToPool.gameObject.SetActive(false);
            poolType.objectPool.Add(objToPool);
        }
    }

    public GameObject GetPoolObject(PoolObjectType type)
    {
        PoolType currentPool = GetPoolType(type);
        List<GameObject> pool = currentPool.objectPool;

        GameObject objToPool = null;
        if(pool.Count > 0 )
        {
            objToPool = pool[pool.Count - 1];
            pool.Remove(objToPool);
        }
        else
        {
            objToPool = Instantiate(currentPool.prefabToPool, currentPool.poolHolder.transform);
        }
        return objToPool;
    }

    public void ReturnObject(GameObject obj, PoolObjectType type)
    {
        obj.SetActive(false);
        PoolType poolList = GetPoolType(type);
        List<GameObject> pool = poolList.objectPool;

        if (!pool.Contains(obj))
            pool.Add(obj);
    }
            
    private PoolType GetPoolType(PoolObjectType type)
    {
        for (int i = 0; i < poolList.Count; i++)
        {
            if (type == poolList[i].type)
            {
                return poolList[i];
            }
        }
        return null;
    }
}
