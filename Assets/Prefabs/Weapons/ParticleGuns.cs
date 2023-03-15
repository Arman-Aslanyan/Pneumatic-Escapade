using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParticleGuns : MonoBehaviour
{
    public KeyCode Attack;
    public KeyCode reload;

    private ParticleSystem Bullet;

    public GameObject spark;
    public float reloadTime;

    public float gunDamage;

    public float currentAmmo;
    public float ammoMax;

    public float firingSpeed;

    public GameObject flash;

    public bool canFire;
    public bool firing;
    public bool reloading;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    private void Start()
    {
        firing = false;
        canFire = true;
        Bullet = GetComponent<ParticleSystem>();
    }
    private void Update()
    {

        if (Input.GetKey(Attack) && canFire == true && currentAmmo > 0 && firing == false)
        {
            Shooting();
        }
        if (Input.GetKeyDown(Attack) && currentAmmo <= 0 && firing == false)
        {
            ShootingBlanks();
        }

        if (Input.GetKeyDown(reload) && currentAmmo != ammoMax && firing == false && reloading != true)
        {
            Reloading();
        }
        if (currentAmmo == 0 && firing == false && reloading != true)
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

        if (other.TryGetComponent(out Combat enemy))
        {
            enemy.TakeDamage(gunDamage);
        }
    }

    public void Shooting()
    {
        Instantiate(flash, transform.position, transform.rotation);
        firing = true;

        Bullet.Play();

        currentAmmo--;
        Invoke("ResetShoot", firingSpeed);

    }

    public void ResetShoot()
    {
        firing = false;
        canFire = true;
    }

    public void ShootingBlanks()
    {
        return;
    }

    public void Reloading()
    {
        canFire = false;
        reloading = true;
        Invoke("ReloadingDone", reloadTime);
    }
    public void ReloadingDone()
    {
        currentAmmo = ammoMax;
        reloading = false;
        canFire = true;
    }
}