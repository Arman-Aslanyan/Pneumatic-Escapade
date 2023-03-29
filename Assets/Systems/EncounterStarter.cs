using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EncounterStarter : MonoBehaviour
{

    public int encounterNum;
    public int encounterLim;

    public int spawnRadius;
    public float spawnTime;
    public SpawnEnemies spEn;

    public BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        spEn = FindObjectOfType<SpawnEnemies>();
        //col = FindObjectOfType<BoxCollider2D>();

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        spEn.EncounterUp(encounterNum);
        spEn.EnemyLimitUp(encounterLim);
        spEn.RestartEnemyEncounter();

        spEn.spawnRadius = spawnRadius;
        spEn.time = spawnTime;
        col.enabled = !col.enabled;

        Debug.Log("Collider.enabled = " + col.enabled);

    }


}
