using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 5f;
	private Rigidbody2D rb;
	private Vector2 movement;
	private Animator animator;
	private SpriteRenderer sr;

	private void Awake() {
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
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

		if (Input.GetAxis("Horizontal") < 0) {
			sr.flipX = true;
		}
		if (Input.GetAxis("Horizontal") > 0) {
			sr.flipX = false;
		}
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Attack pressed");
            animator.SetTrigger("Attack");
        }
	}

	private void FixedUpdate() {
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}
