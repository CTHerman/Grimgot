using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 5f;
    public int dwarfId;
	private Rigidbody2D rb;
	private Vector2 movement;
	private Animator animator;
	private SpriteRenderer sr;

    GameManager gameManager;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
	}

	// Start is called before the first frame update
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {

        if(gameManager.inputEnabled && gameManager.activeDwarfId == dwarfId)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            //animator.SetFloat("Horizontal", movement.x);
            //animator.SetFloat("Vertical", movement.y);

            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetButtonDown("Jump") && gameManager.canSwitchDwarf())
            {
                //halt all movement and animator
                movement.x = 0;
                movement.y = 0;
                animator.SetFloat("Speed", 0);
                gameManager.switchActiveDwarf(dwarfId);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                sr.flipX = true;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                sr.flipX = false;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Attack");
            }
        }

	}

	private void FixedUpdate() {
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}


}
