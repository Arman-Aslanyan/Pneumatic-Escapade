using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public SpawnEnemies spEn;
    public void Start()
    {
        spEn = FindObjectOfType<SpawnEnemies>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        spEn.SpawnABoss();
        gameObject.SetActive(false);
    }
}
