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
    public Transform enemyCenter;
    public Vector2 attackRange;
    public LayerMask playerLayers;
    public int hitStrength;
    public int direction = 1;
    private Rigidbody2D rb;
    public float moveSpeed;
    public float changeDirectionCoolDown;
    public float stopCoolDown;
    public float previouschangeDirection;
    public bool stop;
    private Animator animator;
    private float timer;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        attack();
        walk();
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


    public void attack()
    {
        Collider2D[] hitStuff = Physics2D.OverlapBoxAll(enemyCenter.position, attackRange, playerLayers);

        foreach (Collider2D hitThing in hitStuff)
        {
            // 6 is player
            if (hitThing.gameObject.layer.Equals(9))
            {
                hitThing.GetComponent<PlayerCombat>().takeDamage(hitStrength);
            }
        }

    }


    public void destroy()
    {
        Debug.Log("destroy enemy");
        AudioManager.Play(8);
        Destroy(gameObject);
        gameManager.defeatedEnemys++;
        statusPanel.transform.GetChild(3).GetComponent<Text>().text = gameManager.defeatedEnemys.ToString();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(enemyCenter.position, attackRange);
    }

    private void walk()
    {

        if ((previouschangeDirection + changeDirectionCoolDown) < timer)
        {
            previouschangeDirection = timer;
            stop = true;
            animator.SetFloat("Speed", 0);
            rb.velocity = Vector2.zero;
        }


        if(stop && (previouschangeDirection + stopCoolDown) < timer) {
            stop = false;
            transform.Rotate(0f, 180f, 0f);
            animator.SetFloat("Speed", 1);
        }

        if (!stop)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.isKinematic = false;
            rb.velocity = transform.right * moveSpeed;
        }

    }

}
