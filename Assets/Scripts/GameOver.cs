using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт используется на триггере GameOver который распологается в пропасти

public class GameOver : MonoBehaviour {

	// Таймер смерти
	public float timeDeath = 2f;
	// Точка возврата героя после смерти
	private Vector3 inputPlayer;
	private GameObject player;
	// Убиваляем 1 жизнь у героя
	private ManagerHealth managerHealth;

	// Canvas GameOver
	public GameObject canGameOver;

	float timer = 0f;
	bool death = false;
	bool stay = false;

	// Use this for initialization
	void Start () {
		inputPlayer = transform.GetChild(0).transform.position;
		player = GameObject.FindGameObjectWithTag("Player");
		managerHealth = GameObject.FindGameObjectWithTag("HeathPanel").GetComponent<ManagerHealth>();
	}

	void FixedUpdate() {
		if (stay && death) {
			if (timer <= 0) {
				if (managerHealth.curHealth - 1 > 0) {
					// Отнимаем жизнь у героя
					managerHealth.deathHealth = true;
					managerHealth.DeathHealth();

					player.GetComponent<Animator>().SetTrigger("isLife");
					player.transform.position = player.GetComponent<CharacterControl>().pointLife.transform.position;
					death = false;
					player.GetComponent<CharacterControl>().isDeath = false;

				} else {
					// Отнимаем жизнь у героя
					managerHealth.DeathCurHealth ();
					canGameOver.SetActive(true);
				}
			} else 
				timer -= Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			death = true;
			timer = timeDeath;
			player.GetComponent<Animator>().SetTrigger("isDeath");
			player.GetComponent<CharacterControl>().isDeath = true;
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.tag == "Player") 
			stay = true;
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") 
			stay = false;
	}

}
