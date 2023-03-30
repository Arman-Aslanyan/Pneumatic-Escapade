using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coin;
    public Canvas FinalUI;
    public TMP_Text GameOver;
    public Button Restart;

    private void Start()
    {
        Restart.enabled = false;
        GameOver.text = "";
        FinalUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = ("Coins: " + coins);

        //QoL dev debugging
        if (Input.GetKeyDown(KeyCode.R))
            LevelLoader.Instance.LoadLevel("Menu");
    }

    public void EndGame(string gameOver)
    {
        FinalUI.enabled = true;
        GameOver.text = gameOver;
        Restart.enabled = true;
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
