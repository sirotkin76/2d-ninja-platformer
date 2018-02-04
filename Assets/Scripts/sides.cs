using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sides : MonoBehaviour {

	private CharacterControl characterControl;

	// Use this for initialization
	void Start () {
		characterControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		characterControl.isFly = true;
	}

	void OnTriggerStay2D(Collider2D other) {
		characterControl.isFly = true;
	}

	void OnTriggerExit2D () {
		characterControl.isFly = false;
	}
}
