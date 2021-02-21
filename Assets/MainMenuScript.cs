using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject creditsMenu;
    public GameObject mainMenu;
    public GameObject tutorialText1;
    public GameObject tutorialText2;
    public GameObject tutorialText3;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void quit()
    {
        AudioManager.Play(4);
        Application.Quit();
    }

    public void play()
    {
        AudioManager.Play(4);
        tutorialText1.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void tutText1next()
    {
        AudioManager.Play(4);
        tutorialText1.SetActive(false);
        tutorialText2.SetActive(true);
    }

    public void tutText2next()
    {
        AudioManager.Play(4);
        tutorialText2.SetActive(false);
        tutorialText3.SetActive(true);
    }

    public void tutText3next()
    {
        AudioManager.Play(4);
        SceneManager.LoadScene("Level1");
    }

    public void credits()
    {
        AudioManager.Play(4);
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void back()
    {
        AudioManager.Play(4);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
