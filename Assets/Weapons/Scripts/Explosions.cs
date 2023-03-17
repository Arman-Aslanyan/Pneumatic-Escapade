using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    private object Explosion;

    public float explosionSizeX;
    public float explosionSizeY;
    public float explosionSizeZ;
    public GameObject explosion;

    public WeaponStats stats;

    public float timer;
    public float timerEnd;


    public void Start()
    {
        Explosion = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        explosion.transform.localScale += new Vector3(explosionSizeX, explosionSizeX, explosionSizeZ);

        timer += Time.deltaTime;

        if (timer >= timerEnd)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Combat enemy))
        {
            enemy.TakeDamage(stats.gunDamage);
        }
    }
}
