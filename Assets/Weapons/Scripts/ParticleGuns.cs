using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParticleGuns : MonoBehaviour
{
    public KeyCode Attack;
    public KeyCode Attack2;
    public KeyCode reload;

    private ParticleSystem Bullet;
    public int currentAmmo;

    public WeaponStats stats;


    public bool canFire;
    public bool firing;
    public bool reloading;

    public TMP_Text ammoRemaining;


    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();
    public float rotationSpeed = 45; // degrees per second


    private void Start()
    {
        firing = false;
        canFire = true;
        Bullet = GetComponent<ParticleSystem>();

        currentAmmo = stats.ammoMax;
        ammoRemaining.text = ("Ammo: " + currentAmmo);
    }
    private void Update()
    {
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection =  (Vector2)(mousePosWorld - transform.position).normalized;
        Quaternion goalRotation = Quaternion.LookRotation(lookDirection, Vector2.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, rotationSpeed * Time.deltaTime);

        if(currentAmmo > 0)
        {
            ammoRemaining.text = ("Ammo: " + currentAmmo);
        }
        if(currentAmmo == 0)
        {
            ammoRemaining.text = ("Reloading");
        }

        if (Input.GetKey(Attack) && canFire == true && currentAmmo > 0 && firing == false)
        {
            Shooting();
        }
        if (Input.GetKey(Attack2) && canFire == true && currentAmmo > 0 && firing == false)
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

        if (other.TryGetComponent(out EnemyCombat enemy))
        {
            enemy.TakeDamage(stats.gunDamage);
        }
    }

    public void Shooting()
    {
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