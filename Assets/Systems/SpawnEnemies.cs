using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnEnemies : MonoBehaviour
{
    public float spawnRadius = 7, time = 1.5f;
    public int enemyCount;

    public int encountersSpawned;
    public int encounterLimit;
    public TMP_Text encounterNum;
    public TMP_Text currentEnemyCount;


    public int bossCount;
    public GameObject bossAlert;
    public int bossesSpawned;
    public int bossLimit;

    public GameObject[] enemies;
    public GameObject[] bosses;
    public GameObject Doors;
    // Start is called before the first frame update

    public void Start()
    {
        Doors.SetActive(false);
    }

    public void Update()
    {
        if (enemyCount > 0)
        {
            encounterNum.text = ("Required Defeats: " + enemyCount);
            Doors.SetActive(true);
        }
        else if (enemyCount == 0)
        {
            encounterNum.text = ("");
            currentEnemyCount.text = ("");
            StopCoroutine(SpawnAnEnemy());
            Doors.SetActive(false);
        }
        if (encountersSpawned > 0)
        {
            currentEnemyCount.text = ("enemies remaining: " + encountersSpawned);
        }

        if (enemyCount < 0)
        {
            enemyCount = 0;
        }

    }

    IEnumerator SpawnAnEnemy()
    {
        if (enemyCount > 0 && encountersSpawned <= encounterLimit || encountersSpawned < 2)
        {
            Vector2 spawnPos = GameObject.Find("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(time);
            StartCoroutine(SpawnAnEnemy());
            encountersSpawned++;
        }
    }

    public void SpawnABoss()
    {
            bossAlert.SetActive(true);
            encountersSpawned++;
            Vector2 spawnPos = GameObject.Find("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(bosses[Random.Range(0, bosses.Length)], spawnPos, Quaternion.identity);
    }
    public void EncounterUp(int encounterUp)
    {
        enemyCount = encounterUp;
    }

    public void EnemyLimitUp(int limitUp)
    {
        encounterLimit = limitUp;
    }

    public void RestartEnemyEncounter()
    {
        StartCoroutine(SpawnAnEnemy());
    }

}
