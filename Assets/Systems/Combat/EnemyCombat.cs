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

    public int minCoin;
    public int maxCoin;
    public bool isBoss;

    public SpawnEnemies sE;
    public GameObject spawnEffect;
    public SpawnEnemies spEn;
    public Transform playerPoint;



    // Start is called before the first frame update
    void Start()
    {
        spEn = FindObjectOfType<SpawnEnemies>();
        HP.text = (" ");
        gM = FindObjectOfType<GameManager>();
        sE = FindObjectOfType<SpawnEnemies>();
        playerPoint = GameObject.FindGameObjectWithTag("Player").transform;

        GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
        Instantiate(spawnEffect, transform.position, transform.rotation);
    }

    public void Update()
    {
        if (currentHP <= 0)
        {
            currentHP = 0;
        }
        if (currentHP <= 0)
        {
            Death();
        }
        //transform.LookAt(playerPoint);
    }

    public virtual void TakeDamage(float Damage)
    {
        //Item functionality
        EyeOfRa crit = FindObjectOfType<EyeOfRa>();
        if (crit.InEffect)
        {
            float rand = Random.Range(0f, 1f);
            if (rand >= 1 - (2.5f * crit.stacks))
                Damage *= 2;
        }
        currentHP -= Damage;
        HP.text = ("HP: " + currentHP);

    }

    public virtual void Death()
    {
        sE.encountersSpawned--;
        int dropcoin = Random.Range(minCoin, maxCoin);
        gM.GetCoins(dropcoin);


        //Should the enemy drop an item on death?
        if (isBoss == false)
        {
            sE.enemyCount--;
            float dropItem = Random.Range(0, 1);
            if (dropItem >= 0f)
            {
                print("Item has been dropped");
                FindObjectOfType<RollItem>().Gamble();
            }
        }
        if (isBoss == true)
        {
            spEn.bossCount--;
            spEn.bossAlert.SetActive(false);
            float dropItem = Random.Range(0, 1);
            if (dropItem >= 0.2f)
                FindObjectOfType<RollItem>().Gamble();
            if (spEn.bossCount == 0)
                FindObjectOfType<GameManager>().EndGame();
        }
        Destroy(gameObject);
    }
}
