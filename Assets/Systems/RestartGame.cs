using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        LevelLoader.Instance.LoadLevel("Main");
    }

    public void GoToMenu()
    {
        LevelLoader.Instance.LoadLevel("Menu");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.name == "GoToMenu")
            GoToMenu();
    }
}
