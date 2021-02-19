using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrappedCitizen : DestructableObject
{

    protected GameManager gameManager;
    public GameObject trappedCitizen;
    public GameObject statusPanel;

    protected virtual void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public override void destroy(int dwarfId)
    {
        Debug.Log("trapped citizen destroy");
        gameManager.savedCitizens++;
        AudioManager.Play(0);
        Destroy(gameObject);
        Instantiate(trappedCitizen, gameObject.transform.position, gameObject.transform.rotation);
        statusPanel.transform.GetChild(2).GetComponent<Text>().text = gameManager.savedCitizens.ToString();
    }

}
