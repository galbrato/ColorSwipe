using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {

	public static PointManager instance = null;
	private Text pointsUI;
	private int points = 0;

	void Awake (){
		if (instance == null){
			instance = this;
		} else if (instance != this) {
			Destroy(this.gameObject);
		}
	}

	void Start () {
		pointsUI = this.GetComponent<Text>();
		updatePointsUI();
	}

	public void addPoints(int points){
		this.points += points;
		updatePointsUI();
	}

	void updatePointsUI(){
		pointsUI.text = points.ToString();
	}
	
}
