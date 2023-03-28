using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterStarter : MonoBehaviour
{

    public int encounterNum;
    public int encounterLim;
    public int spawnRadius;
    public int spawnTime;
    public SpawnEnemies spEn;

    // Start is called before the first frame update
    void Start()
    {
        spEn = FindObjectOfType<SpawnEnemies>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        spEn.EncounterUp(encounterNum);
        spEn.EnemyLimitUp(encounterLim);
        spEn.RestartEnemyEncounter();
        spEn.spawnRadius = spawnRadius;
        spEn.time = spawnTime;
        gameObject.SetActive(false);
    }


}
