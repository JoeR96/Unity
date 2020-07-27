using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //UI Variables

    // [SerializeField] private TextMeshProUGUI TimerText;
    // [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI AmmoText;
    // [SerializeField] private Slider _healthSlider;
    // [SerializeField] private Slider _armorSlider;
    [SerializeField] private Image _crosshair;
    
    private float _timer;
    private int _score;
    private int _currentAmmo;
    private int _spareAmmo;

    //Player Variables
    private const float _maxHealth = 100;
    private float _currentArmor;
    private bool _hasArmor;
    private bool _isAlive;

    private float _currentHealth;

    public float CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    //Weapon Variables
    public float _shotDelay;
    
    //Weapon Constructors
    private Camera _mainCamera;

    //Inventory system variables
    [SerializeField] private GameObject _weaponHolder;
    private int _inventCount = 0;
    private int _previousWeapon;
    [SerializeField] private List<BaseWeapon> _weapons = new List<BaseWeapon>();
    [SerializeField] private BaseWeapon _currentWeapon = null;
   
    private void Awake()
    {
        _weapons.Add(_currentWeapon);
        _mainCamera = Camera.main;
        _isAlive = true;
        _hasArmor = false;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, 100);
        CurrentHealth = _maxHealth;
    }
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
     private void Update()
     {
         if (Input.GetKeyDown("r"))
         {
             StartCoroutine(Reload());
         }
         Shoot();
         SwitchWeapon();
         PrintToUI();
         
     }

     #region UIFunctions

     public void AddScore(int damage)
     {
        
     }
     //Go over this
     private void PrintToUI()
     {
         // _healthSlider.value = CurrentHealth;
         // _armorSlider.value = _currentArmor;
         //TIMER IS AWFUL FIX
         _timer += Time.deltaTime;
         //Here we get the first few digits of the timer otherwise the string is too long
         //would like to have done this cleaner
         // TimerText.SetText(_timerString);
         // //score variable to string and printed to UI
         // _score.ToString();
         // ScoreText.SetText("Score " + _score);
         _currentWeapon.Ammo.ToString();
         _currentWeapon.SpareAmmo.ToString();
         AmmoText.SetText( _currentWeapon.Ammo + " | " +_currentWeapon.SpareAmmo);
     }

     #endregion

     #region PlayerFunctions

    
     private void OnTriggerEnter(Collider collision)
     {
         if (collision.CompareTag("Weapon"))
         {
             var toAdd = collision.gameObject.GetComponent<BaseWeapon>();
             if (toAdd.IsPickedUp != false) return;
                 toAdd.IsPickedUp = true;
                 _weapons.Add(toAdd);

            toAdd.transform.parent = _weaponHolder.transform;
            toAdd.transform.localPosition = toAdd.HipFire;
            toAdd.transform.localRotation = toAdd.Rotation;
            _currentWeapon.gameObject.SetActive(false);
            _currentWeapon = toAdd;

         }
         // if (collision.CompareTag("HealthPickup"))
         // {
         //     CurrentHealth += 45;
         // }
         //
         // if (collision.CompareTag("ArmourPickup"))
         // {
         //     _currentArmor += 1;
         // }
         // if (collision.CompareTag("AmmoPickup"))
         // {
         //     
         // }
         
     }

     public void AddArmor()
     {
         _currentArmor++;
     }

     private void PickUpWeapon(BaseWeapon weapon)
     {
         _weapons.Add(weapon);
     }
    
     public void DamagePlayer(float damage)
     {

         {
            _currentHealth -= damage;
            Debug.Log(damage);
         }

         if (_currentHealth <= 0)
         {
             //GameOver.Play();
         }
     }
     #endregion

     #region WeaponFunctions
     
     private void AimDownSight()
     {
         if (Input.GetMouseButton(1))
         {

             _currentWeapon.gunModel.transform.position = _currentWeapon.AimDownSight;
             _crosshair.enabled = false;
         }
         if(Input.GetMouseButtonUp(1))
         {
             _currentWeapon.gunModel.transform.position = _currentWeapon.HipFire;
             _crosshair.enabled = true;
         }
             
     }

     private IEnumerator  Reload()
     {
         _currentWeapon.Canfire = false;
         yield return new WaitForSeconds(_currentWeapon.ReloadSpeed);
         var amountToReload = _currentWeapon.MaxAmmo - _currentWeapon.Ammo;
         {
             _currentWeapon.Ammo += amountToReload;
             _currentWeapon.SpareAmmo -= amountToReload;
         }
         _currentWeapon.Canfire = true;
     }
     
     private void Shoot()
     {
        //how can we make this better?
         if (Input.GetButton("Fire1") && Time.time > _shotDelay && _currentWeapon.Canfire && _currentWeapon.Ammo > 0)
         {
             _shotDelay = Time.time + _currentWeapon.RateOfFire;
             _currentWeapon.Ammo--;
             _currentWeapon.GunAudio.Play();
             _currentWeapon.MuzzleFlash.Play();
             
             Vector3 rayOrigin = _mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
             RaycastHit hit;
             if (Physics.Raycast(rayOrigin,_mainCamera.transform.forward,out hit,_currentWeapon.DamageRange))
             {
                 Debug.Log(hit.collider.name);
                 if (hit.collider.CompareTag("Enemy"))
                 {
                    var enemy = hit.collider.gameObject.GetComponent<BaseEnemy>();
                    enemy.DamageEnemy(_currentWeapon.Damage);
                 }
             }
         }
     }
    //ugly method
     private void SwitchWeapon()
     {
         var previousSelectedWeapon = _inventCount;
         if (Input.GetAxis("Mouse ScrollWheel") > 0f)
         {
             if (_inventCount >= _weapons.Count)
                 _inventCount = 0;
             else
                 _inventCount++;
         }
         if (Input.GetAxis("Mouse ScrollWheel") < 0f)
         {
             if (_inventCount <= 0)
                 _inventCount = _weapons.Count;
             else
                 _inventCount--;
         }

         if (Input.GetKeyDown(KeyCode.Alpha1))
         {
             _inventCount = 0;
         }

         if (Input.GetKeyDown(KeyCode.Alpha2))
         {
             _inventCount = 1;
         }
         if (Input.GetKeyDown(KeyCode.Alpha3))
         {
             _inventCount = 2;
         }
         if (Input.GetKeyDown(KeyCode.Alpha4))
         {
             _inventCount = 3;
         }
         if (previousSelectedWeapon != _inventCount)
         {
             SelectWeapon();
         }
     }

     private void SelectWeapon()
     {
         int i = 0;
         foreach (var weapon in _weapons)
         {
             if (i == _inventCount)
             {
                 _currentWeapon = weapon;
                 weapon.gameObject.SetActive(true);
             }
             else
                 weapon.gameObject.SetActive(false);
             i++;
         }
     }


     
     #endregion

}


