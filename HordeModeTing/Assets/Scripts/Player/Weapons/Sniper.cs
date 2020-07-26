using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sniper : BaseWeapon
{
    public Sniper()
    {
        MuzzleFlash = null;
        //GunAudio = null;
        DamageRange = 450f;
        Damage = 80f;
        CriticalDamage = 160f;
        RateOfFire = 2f;
        NextFire = 0;
        SpareAmmo = 24f;
        MaxAmmo = 6f;
        ReloadSpeed = 1.25f;
        Ammo = 6f;
        IsPickedUp = false;
        Canfire = true;
        HipFire = new Vector3(0.5f, -0.25f, 1.0f);
        Rotation = new Quaternion(90f, 0f, 90f, 0);

    }
    
    [SerializeField] GameObject _scope;
    private Camera _mainCamera;
    

    // Update is called once per frame
    //efficiency
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    
    private void Update()
    {
        //ScopeZoom();;
    }

    private void ScopeZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _mainCamera.fieldOfView = 30;
            _scope.SetActive(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            _mainCamera.fieldOfView = 60;
            _scope.SetActive(false);
        }
    }

    
}
