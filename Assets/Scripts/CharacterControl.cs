using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
	
	public float speed = 5f;
	public float jumpPower = 20f;
	public float jumpLength = 3f;
	private float privateJumpLength;

	private Animator anim;
	private Rigidbody2D ch_contr;
	private bool faceRight = true;
	// Гравитация пресонажа
	private float gravityForce;
	// Направление движение персонажа
	private Vector2 moveVector;

	// ---
	public float groundCheckRadius;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool isGrounded;

	private bool doubleJumped;
	// ---

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		ch_contr = GetComponent <Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		float moveX = Input.GetAxis("Horizontal");

		if (moveX > 0 && !faceRight) {
			flip();
			privateJumpLength = jumpLength;
		} else if (moveX < 0 && faceRight) {
			flip();
			privateJumpLength = jumpLength * -1;
		}
		
		if (isGrounded)
			doubleJumped = false;

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			ch_contr.velocity = new Vector2 (ch_contr.velocity.x + privateJumpLength, jumpPower);
			anim.SetTrigger("isJumping");
		} else {
			if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && !doubleJumped) {
				ch_contr.velocity = new Vector2 (ch_contr.velocity.x + privateJumpLength, jumpPower);
				anim.SetTrigger("isJumping");
				doubleJumped = true;
			}
		}

		if (Input.GetKey (KeyCode.A) && isGrounded) {
			ch_contr.velocity = new Vector2 (-speed, ch_contr.velocity.y);
			anim.SetBool("isRunning", true);
		} else if (Input.GetKey (KeyCode.D) && isGrounded) {
			ch_contr.velocity = new Vector2 (speed, ch_contr.velocity.y);
			anim.SetBool("isRunning", true);
		} else 
			anim.SetBool("isRunning", false);
	}

	void FixedUpdate() {
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Переворачиваем персонажа
	void flip() {
		faceRight = !faceRight;
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	} 

}
