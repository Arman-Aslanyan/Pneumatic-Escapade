using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScriptableObject", menuName = "WeaponStats")]
public class WeaponStats : ScriptableObject
{
    public float startReloadTime;
    public float startGunDamage;
    public int startAmmoMax;
    public float startFiringSpeed;

    public float reloadTime;
    public float gunDamage;
    public int ammoMax;
    public float firingSpeed;

    public void Start()
    {
        reloadTime = startReloadTime;
        gunDamage = startGunDamage;
        ammoMax = startAmmoMax;
        firingSpeed = startFiringSpeed;
    }
}

