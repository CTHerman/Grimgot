using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    GameManager gameManager;

    public GameObject pauseMenuUI;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameManager.inputEnabled)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        gameManager.toggleFreezeGame(true);
        pauseMenuUI.SetActive(true);
    }


    public void Resume()
    {
        gameManager.toggleFreezeGame(false);
        pauseMenuUI.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }

}
