using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public SpawnEnemies spEn;
    public bool isAttached;
    public void Start()
    {
        spEn = FindObjectOfType<SpawnEnemies>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        spEn.SpawnABoss();

        if (isAttached == false)
        {
            gameObject.SetActive(false);
        }
    }
}
