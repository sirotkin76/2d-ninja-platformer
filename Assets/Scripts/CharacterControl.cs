using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
	
	public float speed = 5f;
	public float jumpPower = 20f;
	public float jumpLength = 5f;
	// Задаем точку возврата после смерти
	[HideInInspector]
	public GameObject pointLife;

	private float privateJumpLength;

	private Animator anim;
	private Rigidbody2D ch_contr;
	private bool faceRight = true;
	// Гравитация пресонажа
	private float gravityForce;
	// Направление движение персонажа
	private Vector2 moveVector;

	// --- 
	// Отслеживаем землю
	public float groundCheckRadius;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool isGrounded;

	private bool doubleJumped;
	// ---

	// Отслеживаем куда повернут пероснаж
	bool right = true;

	// Отслеживаем двигается ли в прыжке персонаж или ударился об стену
	public bool isFly;
	private float fly;

	float i = 0;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		ch_contr = GetComponent <Rigidbody2D>();
		pointLife = GameObject.FindGameObjectWithTag("PointLife");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.W) && isGrounded) {
			anim.SetBool("isDoor", true);
		} else 
			anim.SetBool("isDoor", false);
		
		if (isGrounded) {
			doubleJumped = false;
			anim.SetBool("isJumping", false);
		}
		else 
			anim.SetBool("isJumping", true);

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			ch_contr.velocity = new Vector2 (ch_contr.velocity.x + privateJumpLength, jumpPower);
		} else {
			if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && !doubleJumped) {
				ch_contr.velocity = new Vector2 (ch_contr.velocity.x + privateJumpLength, jumpPower);
				doubleJumped = true;
			}
		}

		if (Input.GetKey (KeyCode.A) && isGrounded) {
			ch_contr.velocity = new Vector2 (-speed, ch_contr.velocity.y);
			anim.SetBool("isRunning", true);

			if (right) {
				flip();
				right = false;
				privateJumpLength = jumpLength * -1;
			}

		} else if (Input.GetKey (KeyCode.D) && isGrounded) {
			ch_contr.velocity = new Vector2 (speed, ch_contr.velocity.y);
			anim.SetBool("isRunning", true);

			if (!right) {
				flip();
				right = true;
				privateJumpLength = jumpLength;
			}
		} else {
			anim.SetBool("isRunning", false);

			if (!isGrounded) {

				if (!right) {
					ch_contr.velocity = new Vector2 (-speed, ch_contr.velocity.y);
				} else {
					ch_contr.velocity = new Vector2 (speed, ch_contr.velocity.y);
				}

				if (isFly)
					ch_contr.velocity = new Vector2 (0f, ch_contr.velocity.y);

			} else {
				ch_contr.velocity = new Vector2 (0f, ch_contr.velocity.y);
				isFly = false;
			}

		}
	}

	void FixedUpdate() {
		// Проверяем под ногами слой IsGrounded
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);


	}

	// Переворачиваем персонажа
	void flip() {
		faceRight = !faceRight;
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	} 

}
