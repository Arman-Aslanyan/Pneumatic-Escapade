using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        HP.text = ("HP: " + currentHP);
        gM = FindObjectOfType<GameManager>();
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
