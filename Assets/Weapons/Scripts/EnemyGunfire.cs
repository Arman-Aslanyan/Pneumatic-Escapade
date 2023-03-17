using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunfire : MonoBehaviour
{
    private ParticleSystem Bullet;

    public GameObject spark;
    public GameObject flash;

    public WeaponStats stats;

    public bool canFire;
    public bool firing;
    public bool reloading;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();
    private void Start()
    {
        firing = false;
        canFire = true;
        Bullet = GetComponent<ParticleSystem>();

        stats.currentAmmo = stats.ammoMax;
    }
    private void Update()
    {
        if (canFire == true && stats.currentAmmo > 0 && firing == false)
        {
            Shooting();
        }
        if (stats.currentAmmo <= 0 && firing == false && reloading != true)
        {
            Reloading();
        }
    }

    private void OnParticleCollision(GameObject other)
    {

        int events = Bullet.GetCollisionEvents(other, colEvents);

        for (int i = 0; i < events; i++)
        {
            Instantiate(spark, colEvents[i].intersection, Quaternion.LookRotation(colEvents[i].normal));
        }

        if (other.TryGetComponent(out Combat player))
        {
            player.TakeDamage(stats.gunDamage);
        }

    }
    public void Shooting()
    {
        Instantiate(flash, transform.position, transform.rotation);
        firing = true;

        Bullet.Play();

        stats.currentAmmo--;
        Invoke("ResetShoot", stats.firingSpeed);

    }

    public void ResetShoot()
    {
        firing = false;
        canFire = true;
    }

    public void Reloading()
    {
        canFire = false;
        reloading = true;
        Invoke("ReloadingDone", stats.reloadTime);
    }
    public void ReloadingDone()
    {
        stats.currentAmmo = stats.ammoMax;
        reloading = false;
        canFire = true;
    }
}
