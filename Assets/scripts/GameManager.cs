using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public PlayerVariables playerVariables;
    public Animator playerAnimator;
    public bool inputEnabled = true;
    public int activeDwarfId = 0;
    public int dwarfCount;
    public float switchCoolDown;
    public float previousSwitch;
    public GameObject[] statusPanels;

    //public AudioManager audioManager;

    //stuff to be done before the level starts
    private void Awake()
    {
        activeDwarfId = 0;
        setActiveStatusPanel(activeDwarfId);
        inputEnabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GameOver()
    {
        Time.timeScale = 0f;
        //gameOverUI.SetActive(true);
    }

    public void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToTitle()
    {
        ///SceneManager.LoadScene(0);
    }

    public void toggleFreezeGame(bool freeze)
    {
        playerAnimator.SetBool("inputEnabled", freeze);
        inputEnabled = !freeze;
        Time.timeScale = freeze ? 0f : 1f;
    }

    public bool canSwitchDwarf()
    {
        return (previousSwitch + switchCoolDown) < Time.frameCount;
    }

    public void switchActiveDwarf(int dwarfId)
    {
        Debug.Log("Changing dwarf to " + (dwarfId + 1) % dwarfCount);
        previousSwitch = Time.frameCount;
        setInactiveStatusPanel(activeDwarfId);
        activeDwarfId = (dwarfId + 1) % dwarfCount;
        setActiveStatusPanel(activeDwarfId);
        AudioManager.Play(5);
    }

    public void setActiveStatusPanel(int dwarfId)
    {
        statusPanels[activeDwarfId].GetComponent<Image>().color = new Color32(0, 150, 30, 255);
    }

    public void setInactiveStatusPanel(int dwarfId)
    {
        statusPanels[activeDwarfId].GetComponent<Image>().color = new Color32(255, 255, 225, 80);
    }
}
