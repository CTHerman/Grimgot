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
    private float timer;
    public GameObject[] statusPanels;
    public GameObject[] menuPanels;
    public bool[] trappedDwarfs;
    public int savedCitizens;
    public int defeatedEnemys;
	public CameraController cc;


    //stuff to be done before the level starts
    private void Awake()
    {
        toggleFreezeGame(false);
        activeDwarfId = 0;
        setActiveStatusPanel(activeDwarfId);
        for(int i = 0; i < dwarfCount; i++)
        {
            if(trappedDwarfs[i])
            {
                setTrappedStatusPanel(i);
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
        timer += Time.deltaTime;
    }

    public void toggleFreezeGame(bool freeze)
    {
        inputEnabled = !freeze;
        Time.timeScale = freeze ? 0f : 1f;
    }

    public bool canSwitchDwarf()
    {
        return ((previousSwitch + switchCoolDown) < timer);
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
            previousSwitch = timer;
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

    public void updateHealth(int dwarfId, int dwarfHp)
    {
        if (dwarfHp < 3)
        {
            statusPanels[dwarfId].transform.GetChild(1).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }
        if (dwarfHp < 2)
        {
            statusPanels[dwarfId].transform.GetChild(2).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }
        if (dwarfHp < 1)
        {
            statusPanels[dwarfId].transform.GetChild(3).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }
    }

    public void triggerGameOver()
    {
        AudioManager.Play(12);
        toggleFreezeGame(true);
        menuPanels[1].SetActive(true);
    }


    public void RestartLevel()
    {
        toggleFreezeGame(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
