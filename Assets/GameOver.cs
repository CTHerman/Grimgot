using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    GameManager gameManager;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void retry()
    {
        gameManager.RestartLevel();
    }

    public void quit()
    {
        Application.Quit();
    }

}
