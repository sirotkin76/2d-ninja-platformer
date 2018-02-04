using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerPause : MonoBehaviour {

	private bool pause;
	private Image image; 
	private GameObject buttonsPause;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		buttonsPause = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			pause = !pause;

		if (pause) {
			Time.timeScale = 0;
			image.enabled = true;
			buttonsPause.SetActive(true);
		} else {
			Time.timeScale = 1;
			image.enabled = false;
			buttonsPause.SetActive(false);
		}
	}

	public void ContinueGame() {
		pause = !pause;
	}

	public void ExitGame() {
		Application.Quit();
	}

	public void NewGame() {
		Application.LoadLevel("scene01");
	}

	public void SettingsGame() {

	}

	public void BasicMenuGame() {


	}
}
