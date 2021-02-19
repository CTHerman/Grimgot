using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    private Animator animator;
    public int dwarfId;
    public int dwarfHp;
    GameManager gameManager;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.inputEnabled && gameManager.activeDwarfId == dwarfId)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }
        }

    }

    private void Attack()
    {

        animator.SetTrigger("Attack");

        Collider2D[] hitStuff = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D hitThing in hitStuff)
        {
            Debug.Log("Item hit: " + hitThing.name + " on layer " + hitThing.gameObject.layer);
            // 6 is destructable object layer
            if (hitThing.gameObject.layer.Equals(6))
            {
                hitThing.GetComponent<DestructableObject>().destroy(dwarfId);
            }
        }

    }

}