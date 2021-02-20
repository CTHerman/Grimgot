using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int[] dwarfDamage;
    public int hp;
    public GameObject statusPanel;
    protected GameManager gameManager;

    protected virtual void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void applyDamage(int dwarfId)
    {

        hp -= dwarfDamage[dwarfId];
        if(hp < 1)
        {
            destroy();
        } else {
            AudioManager.Play(10);
        }

    }

    public void destroy()
    {
        Debug.Log("destroy enemy");
        AudioManager.Play(16);
        Destroy(gameObject);
        gameManager.defeatedEnemys++;
        statusPanel.transform.GetChild(3).GetComponent<Text>().text = gameManager.defeatedEnemys.ToString();
    }
}
