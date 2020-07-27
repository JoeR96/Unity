using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]        
    private float _currentHealth;
    private float _maxHealth;
    private bool _isDead;
    [SerializeField]
    public PoolObjectType EnemyItem;
    [SerializeField]
    public PoolObjectType Type;
    [SerializeField]
    public Transform Player;
    [SerializeField]
    //Protected so it is accessible only to derived class
    //this will be our base speed value that will be different dependant on the enemy
    protected float _baseSpeed;

    [SerializeField]


    public float CurrentHealth
    {
        get 
        { return _currentHealth; }
        set 
        { _currentHealth = value;}
        
    }

    public float MaxHealth
    {
        get
        { return _maxHealth; }
        set
        { _maxHealth = value; }
    }


    private void Awake()
    {
        _isDead = false;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }


    public void DamageEnemy(float damage)
    {
        if (!_isDead)
            _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            GameManager.instance.EnemyCounter--;
            _isDead = true;
            Return();
        }

    }

    private void Return()
    {
        PoolManager.instance.ReturnObject(this.gameObject, Type);
    }
}
