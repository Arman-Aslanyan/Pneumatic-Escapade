using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScriptableObject", menuName = "WeaponStats")]
public class WeaponStats : ScriptableObject
{
    public float reloadTime;
    public float gunDamage;
    public int currentAmmo;
    public int ammoMax;
    public float firingSpeed;
}
