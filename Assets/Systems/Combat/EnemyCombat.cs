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
    public bool doesDeactivate;
    public SealedGateControl sGC;
    public GameObject setAct;

    public int minCoin;
    public int maxCoin;
    public bool isBoss;

    public GameObject spawnEffect;
    public SpawnEnemies spEn;
    public Transform playerPoint;


    // Start is called before the first frame update
    void Start()
    {
        spEn = FindObjectOfType<SpawnEnemies>();
        //sGC = FindObjectOfType<SealedGateControl>();
        if (HP != null)
        {
            HP.text = (" ");
        }
        gM = FindObjectOfType<GameManager>();
        playerPoint = GameObject.FindGameObjectWithTag("Player").transform;
        sGC = FindObjectOfType<SealedGateControl>();
        if (doesDeactivate == false)
        {
            GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        Instantiate(spawnEffect, transform.position, transform.rotation);
    }

    public void Update()
    {
        if (currentHP <= 0)
        {
            currentHP = 0;
            Death();
        }
        //transform.LookAt(pla);
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
        if(HP != null)
        {
            HP.text = ("HP: " + currentHP);
        }
    }

    public virtual void Death()
    {
        if (spEn != null)
        {
            spEn.encountersSpawned--;
        }
        int dropcoin = Random.Range(minCoin, maxCoin);
        gM.GetCoins(dropcoin);


        //Should the enemy drop an item on death?
        if (isBoss == false && doesDeactivate == false)
        {
            if (spEn != null)
            {
                spEn.enemyCount--;
            }
            float dropItem = Random.Range(0, 1);
            if (dropItem >= 0f)
            {
                print("Item has been dropped");
                FindObjectOfType<RollItem>().Gamble();
                Destroy(gameObject);
            }
        }
        if (isBoss == true && doesDeactivate == false)
        {
            spEn.bossCount--;
            spEn.bossAlert.SetActive(false);
            float dropItem = Random.Range(0, 1);
            if (dropItem >= 0.2f)
                FindObjectOfType<RollItem>().Gamble();
            if (spEn.bossCount == 0)
                FindObjectOfType<GameManager>().EndGame();
            Destroy(gameObject);
        }
        if(doesDeactivate == true)
        {
            sGC.Unseal();
            setAct.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
