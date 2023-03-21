using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParticleGuns : MonoBehaviour
{
    public KeyCode Attack;
    public KeyCode reload;

    private ParticleSystem Bullet;
    public int currentAmmo;

    public GameObject spark;
    public WeaponStats stats;

    public GameObject flash;

    public bool canFire;
    public bool firing;
    public bool reloading;



    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();
    public float rotationSpeed = 45; // degrees per second


    private void Start()
    {
        firing = false;
        canFire = true;
        Bullet = GetComponent<ParticleSystem>();

        currentAmmo = stats.ammoMax;
    }
    private void Update()
    {
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDirection = (mousePosWorld - transform.position).normalized;
        Quaternion goalRotation = Quaternion.LookRotation(lookDirection, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, rotationSpeed * Time.deltaTime);

        if (Input.GetKey(Attack) && canFire == true && currentAmmo > 0 && firing == false)
        {
            Shooting();
        }

        if (Input.GetKeyDown(reload) && currentAmmo != stats.ammoMax && firing == false && reloading != true)
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
            Instantiate(spark,transform.position, Quaternion.identity);
        }

        if (other.TryGetComponent(out Combat enemy))
        {
            enemy.TakeDamage(stats.gunDamage);
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

    public void ShootingBlanks()
    {
        return;
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