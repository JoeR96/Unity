using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    //get ref to FPSCam??
    public GameObject gunModel;
    public ParticleSystem MuzzleFlash;
    public AudioSource GunAudio;
    public float NextFire;
    public float DamageRange;
    public float MaxAmmo;
    public float Ammo;
    public float RateOfFire;
    public float Damage;
    public float CriticalDamage;
    public float SpareAmmo;
    public float ReloadSpeed;
    public bool IsPickedUp;
    public bool Canfire;
    public Vector3 AimDownSight;
    public Vector3 HipFire;
    public Quaternion Rotation;
}
