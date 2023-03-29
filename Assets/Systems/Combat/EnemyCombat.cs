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
    public bool isBoss;

    public SpawnEnemies sE;
    public GameObject spawnEffect;
    public SpawnEnemies spEn;



    // Start is called before the first frame update
    void Start()
    {
        spEn = FindObjectOfType<SpawnEnemies>();
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
        if (isBoss == false)
        {
            float dropItem = Random.Range(0, 1);
            if (dropItem >= 0.825f)
                FindObjectOfType<RollItem>().Gamble();
        }
        if (isBoss == true)
        {
            spEn.bossAlert.SetActive(false);
            float dropItem = Random.Range(0, 1);
            if (dropItem >= 0.2f)
                FindObjectOfType<RollItem>().Gamble();
        }
        Destroy(gameObject);
    }
}
