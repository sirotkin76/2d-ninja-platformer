using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	[SerializeField]
	// На уровне имеется только 1 дверь
	private GameObject door;

	bool openDoor;
	


	// Use this for initialization
	void Start () {
		door = GameObject.FindGameObjectWithTag("Door").gameObject;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			transform.GetChild (0).gameObject.SetActive (true);
			transform.GetChild (1).gameObject.SetActive (false);

			door.transform.GetChild (0).gameObject.SetActive (true);
			door.transform.GetChild (1).gameObject.SetActive (false);
		}
	}
	
}
