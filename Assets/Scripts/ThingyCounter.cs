using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThingyCounter : MonoBehaviour {

	public Text counterUI;
	private Transform transf;

	void Start () {
		transf = this.GetComponent<Transform>();
	}
	
	void Update () {
		counterUI.text = transf.childCount.ToString();
	}
}
