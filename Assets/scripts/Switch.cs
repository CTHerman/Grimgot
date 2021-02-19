using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : DestructableObject
{
    public GameObject objectToRemove;
    public bool activated = false;
    public SpriteRenderer spriteRenderer;
    public Sprite activatedSpirte;

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
        if(!activated && whoCanDestroy[dwarfId])
        {
            Debug.Log("remove object");
            AudioManager.Play(14);
            Destroy(objectToRemove);
            activated = true;
            spriteRenderer.sprite = activatedSpirte;

        }
        else
        {
            AudioManager.Play(15);
        }

    }

}
