using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : BaseWeapon
{
    public Rifle()
    {
        MuzzleFlash = null;
        GunAudio = null;
        DamageRange = 60f;
        Damage = 40f;
        CriticalDamage = 80f;
        RateOfFire = 0.1f;
        NextFire = 0;
        SpareAmmo = 180f;
        MaxAmmo = 30f;
        Ammo = 30f;
        Canfire = true;
        HipFire = new Vector3(0.5f, -0.25f, 1.0f);
        Rotation = new Quaternion(90f, 0f, 90f, 0);
    }
}
