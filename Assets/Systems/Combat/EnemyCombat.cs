using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Pathfinding;

public class EnemyCombat : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    public TMP_Text HP;
    private GameManager gM;
    public int gainedCoins;

    public SpawnEnemies sE;
    public GameObject spawnEffect;



    // Start is called before the first frame update
    void Start()
    {
        HP.text = (" ");
        gM = FindObjectOfType<GameManager>();
        sE = FindObjectOfType<SpawnEnemies>();

        GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
        Instantiate(spawnEffect, transform.position, transform.rotation);
    }

    public virtual void TakeDamage(float Damage)
    {
        currentHP -= Damage;
        HP.text = ("HP: " + currentHP);

        if (currentHP <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Debug.Log("dead");
        gM.GetCoins(gainedCoins);
        sE.enemyCount--;
        sE.encountersSpawned--;
        //Should the enemy drop an item on death?
        float dropItem = Random.Range(0, 1);
        if (dropItem >= 0.825f)
            FindObjectOfType<RollItem>().Gamble();
        Destroy(gameObject);
    }
}
