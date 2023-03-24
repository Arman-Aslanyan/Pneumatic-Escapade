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



    // Start is called before the first frame update
    void Start()
    {
        HP.text = (" ");
        gM = FindObjectOfType<GameManager>();

        GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
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
        Destroy(gameObject);
    }
}
