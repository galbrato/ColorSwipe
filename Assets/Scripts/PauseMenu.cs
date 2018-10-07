using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	private bool isMenuOpen = false;
	private GameObject menuObject;

	void Start(){
		menuObject = this.GetComponent<Transform>().Find("Menu").gameObject;
	}

	void changeState(){
		isMenuOpen = !isMenuOpen;
		menuObject.gameObject.SetActive(isMenuOpen);
		if (isMenuOpen)
			Time.timeScale = 0f;
		else Time.timeScale = 1f;
	}	

	void Update () {
		if (Input.GetKeyUp("escape")) changeState();
	}
}
