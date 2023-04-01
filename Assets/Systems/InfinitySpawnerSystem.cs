using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfinitySpawnerSystem : MonoBehaviour
{
    public float spawnRadius = 7, time = 1.5f;
    public int enemyCount;

    public int encountersSpawned;
    public TMP_Text encounterNum;

    public int spawnLevel1;
    public int spawnLevel2;
    public int spawnLevel3;
    public int spawnLevel4;
    public int spawnLevelFinal;

    public int spawnBoss1;
    public int spawnBoss2;
    public int spawnBossFinal;

    public int tierFinal;
    public GameObject spawnPoint;


    public int bossCount;
    public GameObject bossAlert;
    public int bossesSpawned;
    public int bossTime;

    public GameObject[] enemies;
    public GameObject[] bosses;
    // Start is called before the first frame update

    public void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    public void Update()
    {
        if (encountersSpawned == spawnLevelFinal)
        {
            StartCoroutine(SpawnABoss());
        }
        encounterNum.text = ("Encounters Spawned : " + encountersSpawned);
        if (enemyCount < 0)
        {
            enemyCount = 0;
        }

        if (encountersSpawned > spawnLevel1 && encountersSpawned < spawnLevel2)
        {
            time = 2;
        }
        if (encountersSpawned > spawnLevel2 && encountersSpawned < spawnLevel3)
        {
            time = 1.5f;
        }
        if (encountersSpawned > spawnLevel3 && encountersSpawned < spawnLevel4)
        {
            time = 1;
        }
        if (encountersSpawned > spawnLevel4 && encountersSpawned < spawnLevelFinal)
        {
            time = 0.55f;
        }
        if (encountersSpawned > spawnLevelFinal)
        {
            bossTime = 20;
        }
        if (encountersSpawned > spawnLevelFinal && encountersSpawned < spawnBoss1)
        {
            bossTime = 15;
        }
        if (encountersSpawned > spawnBoss1 && encountersSpawned < spawnBoss2)
        {
            bossTime = 10;
        }
        if (encountersSpawned > spawnBoss2 && encountersSpawned < spawnBossFinal)
        {
            bossTime = 7;
        }
        if (encountersSpawned > spawnBossFinal && encountersSpawned < tierFinal)
        {
            bossTime = 5;
        }
        if (encountersSpawned > tierFinal)
        {
            time = 0.1f;
            bossTime = 3;
        }

    }

    IEnumerator SpawnAnEnemy()
    {

        Vector2 spawnPos = spawnPoint.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
            encountersSpawned++;
            yield return new WaitForSeconds(time);
            StartCoroutine(SpawnAnEnemy());
    }

    public IEnumerator SpawnABoss()
    {
            bossAlert.SetActive(true);
            Vector2 spawnPos = GameObject.Find("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(bosses[Random.Range(0, bosses.Length)], spawnPos, Quaternion.identity);
            encountersSpawned++;
            yield return new WaitForSeconds(bossTime);
            StopCoroutine(SpawnABoss());
    }

}
