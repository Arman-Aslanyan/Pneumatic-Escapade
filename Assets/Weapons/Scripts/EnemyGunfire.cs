using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunfire : MonoBehaviour
{
    private ParticleSystem Bullet;

    public Transform playerPoint;

    public GameObject spark;
    public GameObject flash;
    public int currentAmmo;

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

        playerPoint = GameObject.FindGameObjectWithTag("Player").transform;

        currentAmmo = stats.ammoMax;
    }
    private void Update()
    {
        if (canFire == true && currentAmmo > 0 && firing == false)
        {
            Shooting();
        }
        if (currentAmmo <= 0 && firing == false && reloading != true)
        {
            Reloading();
        }

        transform.LookAt(playerPoint);

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

        currentAmmo--;
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
        currentAmmo = stats.ammoMax;
        reloading = false;
        canFire = true;
    }
}
