using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseWeapon
{
    public Pistol()
    {
        MuzzleFlash = null;
        GunAudio = null;
        DamageRange = 15f;
        Damage = 20;
        CriticalDamage = 40f;
        RateOfFire = 1f;
        NextFire = 0;
        SpareAmmo = 24f;
        MaxAmmo = 12f;
        Ammo = 12f;
        ReloadSpeed = 5f;
        Canfire = true;
        AimDownSight = new Vector3(0.0625f,-0.0625f,0.725f);
        HipFire = new Vector3(0.5f, 0.5f, -1.0f);
        
    }

}
