using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappedDwarf : DestructableObject
{
    public int trappedDwarfId;
    protected GameManager gameManager;
    public GameObject trappeDwarf;

    protected virtual void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void destroy(int dwarfId)
    {
        Debug.Log("trapped dwarf destroy");
        gameManager.freeDwarf(trappedDwarfId);
        AudioManager.Play(0);
        Destroy(gameObject);
        Instantiate(trappeDwarf, gameObject.transform.position, gameObject.transform.rotation);
    }

}
