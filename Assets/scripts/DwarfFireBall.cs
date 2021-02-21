using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfFireBall : MonoBehaviour
{
    public float moveSpeed;
    public int damage = 1;
    public int dwarfId;
    public Rigidbody2D rb;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private Vector2 movement;
    public int direction = 1;
    private SpriteRenderer sr;

    public float timeAlive;
    private float timer;
    private float createTime;

    void Awake()
    {
        createTime = Time.deltaTime;
        rb.velocity = transform.right * moveSpeed * direction;
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if((createTime + timeAlive) < timer)
        {
            Destroy(gameObject);
        }

        Collider2D[] hitStuff = Physics2D.OverlapCircleAll(rb.position, attackRange, enemyLayers);

        foreach (Collider2D hitThing in hitStuff)
        {
            Debug.Log("Item hit: " + hitThing.name + " on layer " + hitThing.gameObject.layer);
            // 6 is destructable object layer
            if (hitThing.gameObject.layer.Equals(6))
            {
                hitThing.GetComponent<DestructableObject>().destroy(dwarfId);
            }
            // 7 is enemy layer
            else if (hitThing.gameObject.layer.Equals(7))
            {
                hitThing.GetComponent<Enemy>().applyDamage(dwarfId);
            }

            //something was hit, so remove the fireball
            Destroy(gameObject);
        }
    }
    
}
