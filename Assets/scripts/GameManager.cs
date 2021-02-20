using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator playerAnimator;
    public bool inputEnabled = true;
    public int activeDwarfId = 0;
    public int dwarfCount;
    public float switchCoolDown;
    public float previousSwitch;
    public GameObject[] statusPanels;
    public bool[] trappedDwarfs;
    public int savedCitizens;
    public int defeatedEnemys;
	public CameraController cc;


    //stuff to be done before the level starts
    private void Awake()
    {
        activeDwarfId = 0;
        //set active dwarf and assign the other two as trapped
        trappedDwarfs = new bool[dwarfCount];
        setActiveStatusPanel(activeDwarfId);
        for(int i = 0; i < dwarfCount; i++)
        {
            if(i == activeDwarfId)
            {
                trappedDwarfs[i] = false;
            } else
            {
                setTrappedStatusPanel(i);
                trappedDwarfs[i] = true;
            }
        }
        inputEnabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
		cc = FindObjectOfType<CameraController>();   
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
        return ((previousSwitch + switchCoolDown) < Time.frameCount);
    }

    public int getNextDwarf(int dwarfId)
    {

        Debug.Log("get next dwarf begin with " + dwarfId);
        int dwarfIndex = 0;
        int nextDwarf = dwarfId;
        while(dwarfIndex < dwarfCount)
        {
            nextDwarf = (nextDwarf + 1) % dwarfCount;
            Debug.Log("check next " + nextDwarf);
            if (!trappedDwarfs[nextDwarf])
            {
                Debug.Log(nextDwarf + " is not trapped");
                return nextDwarf;
            }
            Debug.Log(nextDwarf + " is trapped");
            dwarfIndex++;
        }
        //return same id if no one else free yet
        return dwarfId;
    }

    public void switchActiveDwarf(int dwarfId)
    {

        int nextDwarf = getNextDwarf(dwarfId);
        if(nextDwarf != dwarfId)
        {
            Debug.Log("Changing dwarf to " + nextDwarf);
            previousSwitch = Time.frameCount;
            setInactiveStatusPanel(dwarfId);
            setActiveStatusPanel(nextDwarf);
            activeDwarfId = nextDwarf;
			cc.SetTarget(nextDwarf);
            AudioManager.Play(5);
        }

    }

    public void setActiveStatusPanel(int dwarfId)
    {
        statusPanels[dwarfId].GetComponent<Image>().color = new Color32(0, 150, 30, 255);
    }

    public void setInactiveStatusPanel(int dwarfId)
    {
        statusPanels[dwarfId].GetComponent<Image>().color = new Color32(255, 255, 225, 80);
    }

    public void setTrappedStatusPanel(int dwarfId)
    {
        statusPanels[dwarfId].transform.GetChild(0).GetComponent<Image>().color = new Color32(60, 60, 60, 100);
        statusPanels[dwarfId].transform.GetChild(1).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        statusPanels[dwarfId].transform.GetChild(2).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        statusPanels[dwarfId].transform.GetChild(3).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
    }

    public bool isDwarfTrapped(int dwarfId)
    {
        return trappedDwarfs[dwarfId];
    }

    public void freeDwarf(int dwarfId)
    {
        trappedDwarfs[dwarfId] = false;
        statusPanels[dwarfId].transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        statusPanels[dwarfId].transform.GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        statusPanels[dwarfId].transform.GetChild(2).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        statusPanels[dwarfId].transform.GetChild(3).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

}
