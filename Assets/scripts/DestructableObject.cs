using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    public bool[] whoCanDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void destroy(int dwarfId)
    {
        if (whoCanDestroy[dwarfId])
        {
            Debug.Log("destroy object");
            AudioManager.Play(8);
            Destroy(gameObject);
        } else
        {
            AudioManager.Play(15);
        }
    }

}
