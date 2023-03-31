using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunfire : MonoBehaviour
{
    private ParticleSystem Bullet;

    public Transform playerPoint;
    public int currentAmmo;

    public WeaponStats stats;

    public bool canFire;
    public bool firing;
    public bool reloading;
    public bool turret;

    public float shakeTime;
    public float shakeIntensity;

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

        if (turret == false)
        {
            transform.LookAt(playerPoint);
        }

    }

    private void OnParticleCollision(GameObject other)
    {

        int events = Bullet.GetCollisionEvents(other, colEvents);

        if (other.TryGetComponent(out Combat player))
        {
            player.TakeDamage(stats.gunDamage);
        }

    }
    public void Shooting()
    {
        firing = true;

        Bullet.Play();
        if (!CompareTag("ForTutorial"))
            CinemachineShake.Instance.ShakeCamera(shakeIntensity, shakeTime);

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
