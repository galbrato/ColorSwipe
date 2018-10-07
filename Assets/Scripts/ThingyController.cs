using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingyController : MonoBehaviour {
	private Rigidbody2D rigid;
	public float velocityFactor;

	public static float swipeMinimumDistance = 5f;
	private bool isSwipeCheckStarted = false;
	private bool isSwipeCheckFinalized = false;
	private bool isSwipeCheckUsed = false;
	private Vector2 swipeStart;
	private string swipeResult = null;
		
	void Start () {
		rigid = this.GetComponent<Rigidbody2D>();
	}

	Vector2 checkInput(){
		Vector2 inputs = Vector2.zero;

		// checking left swipe/key
		if (Input.GetKeyDown("left") || (isSwipeCheckFinalized && !isSwipeCheckUsed && swipeResult == "left")){
			inputs += Vector2.left;
		}

		// checking right swipe/key
		if (Input.GetKeyDown("right") || (isSwipeCheckFinalized && !isSwipeCheckUsed && swipeResult == "right")){
			inputs += Vector2.right;
		}

		// checking up swipe/key
		if (Input.GetKeyDown("up") || (isSwipeCheckFinalized && !isSwipeCheckUsed && swipeResult == "up")){
			inputs += Vector2.up;
		}

		if (isSwipeCheckFinalized) isSwipeCheckUsed = true;

		return inputs;
	}

	void checkSwipe(){
		if (isSwipeCheckStarted && !isSwipeCheckFinalized){
			Vector2 actualPos = Input.mousePosition;
			Vector2 distance = actualPos - swipeStart;
			if (distance.magnitude >= ThingyController.swipeMinimumDistance){
				distance.Normalize();

				if (distance.y > 0.4f) swipeResult = "up";
				else if (distance.x > 0f) swipeResult = "right";
				else swipeResult = "left";

				isSwipeCheckFinalized = true;
			}
		} else {
			if (Input.GetMouseButtonDown(0)){
				isSwipeCheckStarted = true;
				swipeStart = Input.mousePosition;
			}
		}

		if (Input.GetMouseButtonUp(0)){
			isSwipeCheckStarted = false;
			isSwipeCheckFinalized = false;
			isSwipeCheckUsed = false;
			swipeResult = null;
			Debug.Log("swipe reset");
		}
	}

	void addVelocity(Vector2 inputs){
		Vector2 newVelocity = inputs * velocityFactor;
		rigid.velocity = newVelocity;
	}
	
	void Update () {
		checkSwipe();

		Vector2 inputs = checkInput();
		if (inputs != Vector2.zero){
			addVelocity(inputs);
		}
	}
}
