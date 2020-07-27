using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseEnemy : MonoBehaviour
{
    #region variables
    [SerializeField]
    private float _currentHealth;
    private float _maxHealth;
    private bool _isDead;
    private float _damage;
    //Protected so it is accessible only to derived class
    //this will be our base speed value that will be different dependant on the enemy
    protected float _baseSpeed;
    protected float _maxSpeed;
    protected float _currentSpeed;
    protected float _distance;

    protected PoolObjectType EnemyItem;
    protected PoolObjectType Type;

    [SerializeField] GameObject Explosion;
    protected Transform Player;

    public float CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    protected float MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }
    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }


    #endregion
    private void Awake()
    {
        _isDead = false;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    protected virtual void DamageEnemy(float damage)
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
    protected virtual void OnTriggerEnter(Collider other,float damage)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hi");    
            other.GetComponent<Player>().DamagePlayer(damage);
        }
    }
    protected void Return()
    {
        PoolManager.instance.ReturnObject(gameObject, Type);
    }
}
