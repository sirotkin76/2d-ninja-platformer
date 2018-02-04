using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerHealth : MonoBehaviour {

	private int maxHealth = 5;
	public int curHealth = 3;
	// Отнимаем 1 жизнь
	public bool deathHealth;

	private GameObject player;
	private int getChildCount;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		getChildCount = transform.GetChildCount();
		DeathHealth();
		maxHealth = transform.GetChildCount();
	}
	
	// Update is called once per frame
	void Update () {
		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}
		else {
			if (curHealth < 0) {
				curHealth = 0;
				DeathHealth();
			}
		}

		if (deathHealth) {
			DeathCurHealth ();
		}

		deathHealth = false;
	}

	public void DeathCurHealth () {
		curHealth--;
		DeathHealth();
	}

	public void DeathHealth() {
		for (int i = 0; i < maxHealth; i++) {
			if (curHealth > i && curHealth > 0) {
				transform.GetChild(i).gameObject.active = true;
			} else {
				transform.GetChild(i).gameObject.active = false;
			}
		}
	}
}
