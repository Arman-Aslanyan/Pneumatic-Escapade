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

    public GameObject[] enemies;
    // Start is called before the first frame update

    public void Update()
    {

        if(enemyCount < 0)
        {
            enemyCount = 0;
        }
        if (enemyCount > 0)
        {
            encounterNum.text = ("Required Defeats: " + enemyCount);
        }
        else if (enemyCount == 0)
        {
            encounterNum.text = ("");
        }


        currentEnemyCount.text = ("Enemies Alive: " + encountersSpawned);
        
        if(encountersSpawned == 0)
        {
            currentEnemyCount.text = ("");
        }    

        if (Input.GetKeyDown(KeyCode.J))
        {
            RestartEnemyEncounter();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            EncounterUp();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            EnemyLimitUp();
        }



    }

    IEnumerator SpawnAnEnemy()
    {
        if (enemyCount > 0 && encountersSpawned <= encounterLimit || encountersSpawned < 2)
        {
            encountersSpawned++;
            Vector2 spawnPos = GameObject.Find("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(time);
            StartCoroutine(SpawnAnEnemy());
        }
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
