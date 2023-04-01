using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coin;

    // Update is called once per frame
    void Update()
    {
        coin.text = ("Coins: " + coins);
    }

    public void EndGame()
    {
        LevelLoader.Instance.LoadLevel("GameOver");
    }

    public void RestartGame()
    {
        LevelLoader.Instance.LoadLevel("Main");
    }

    public void GetCoins(int gainedCoins)
    {
        coins += gainedCoins;
    }
}
