using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = ("Coins: " + coins);

        //QoL dev debugging
        if (Input.GetKeyDown(KeyCode.R))
            LevelLoader.Instance.LoadLevel("Menu");
    }

    public void GetCoins(int gainedCoins)
    {
        coins += gainedCoins;
    }
}
