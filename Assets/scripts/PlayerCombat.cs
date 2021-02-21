using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{

    private Animator animator;
    public int dwarfId;
    public int dwarfHp;
    GameManager gameManager;
    public GameObject fireBall;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackCoolDown; 
    public float takedmgCoolDown;
    public float previousAttack;
    public float previousTakedmg;
    private SpriteRenderer sr;
    private float timer;

    public float attackDuraction;
    public float attackActiveTimer;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        previousAttack = 0;
        previousTakedmg = 0;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (gameManager.inputEnabled && gameManager.activeDwarfId == dwarfId)
        {
            if (Input.GetButtonDown("Fire1") && ((previousAttack + attackCoolDown) < timer) && gameManager.inputEnabled)
            {
                previousAttack = timer;
                animator.SetTrigger("Attack");
                //check if mage, hard coding for now since we have only 1 project user
                if (dwarfId == 2)
                {
                    rangedAttack();
                } else
                {
                    meleeAttack();
                    attackActiveTimer = timer + attackDuraction;
                }
            }
            //trying to allow attack hurt box to be active longer, so enemys dont appear to walk right through weapon and not die
            else if (dwarfId != 2 && attackActiveTimer > timer)
            {
                meleeAttack();
            }
        }

        
        if(previousTakedmg > 0 && (previousTakedmg + takedmgCoolDown) < timer)
        {
            previousTakedmg = 0;
            sr.color = new Color32(255, 255, 255, 255); 
        }
        
    }

    private void meleeAttack()
    {

        Collider2D[] hitStuff = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D hitThing in hitStuff)
        {
            Debug.Log("Item hit: " + hitThing.name + " on layer " + hitThing.gameObject.layer);
            // hit something, so stop hitbox from spawning for duration of attack
            attackActiveTimer = 0f;

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
        }

    }

    public void takeDamage(int damage)
    {
        if ((previousTakedmg + takedmgCoolDown) < timer) {
            Debug.Log("Took damage!! cooldown: " + previousTakedmg);
            previousTakedmg = timer;
            dwarfHp -= damage;
            gameManager.updateHealth(dwarfId, dwarfHp);
            sr.color = new Color32(165, 90, 90, 255);
            if (dwarfHp < 1)
            {
                Debug.Log("Dwarf has died!");
                gameManager.triggerGameOver();
                animator.SetBool("inputEnabled", gameManager.inputEnabled);
            } else
            {
                AudioManager.Play(10);
            }
        }

    }

    private void rangedAttack()
    {
        GameObject newFireBall = Instantiate(fireBall, attackPoint.position, attackPoint.rotation);
        //newFireBall.GetComponent<DwarfFireBall>().direction =
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
