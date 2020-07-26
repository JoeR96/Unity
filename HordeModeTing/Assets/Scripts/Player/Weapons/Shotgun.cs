using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Shotgun : BaseWeapon
{
    public Shotgun()
    {
        MuzzleFlash = null;
        GunAudio = null;
        DamageRange = 450f;
        Damage = 75f;
        CriticalDamage = 150f;
        RateOfFire = 0.5f;
        NextFire = 0;
        SpareAmmo = 24f;
        MaxAmmo = 2f;
        Ammo = 2f;
        ReloadSpeed = 1.25f;
        Canfire = true;
        HipFire = new Vector3(0.5f, -0.25f, 1.0f);
        Rotation = new Quaternion(90f, 0f, 90f, 0);

    }
}
