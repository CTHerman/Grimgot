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
    public Transform attackPoint;
    private int direction;

    GameManager gameManager;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
        direction = 1; //facing right

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
                // hacky and will only work with left/right movement
                if(direction != -1)
                {
                    direction = -1;
                    flipAttackPointOnX();
                }
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                sr.flipX = false;
                // hacky and will only work with left/right movement
                if (direction != 1)
                {
                    direction = 1;
                    flipAttackPointOnX();
                }
            }

        }

	}

	private void FixedUpdate() {
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}

    private void flipAttackPointOnX()
    {
        attackPoint.transform.localPosition = new Vector3(attackPoint.transform.localPosition.x * -1,
                                                       attackPoint.transform.localPosition.y,
                                                       attackPoint.transform.localPosition.z);
    }
}
