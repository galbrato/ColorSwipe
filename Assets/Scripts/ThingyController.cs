using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingyController : MonoBehaviour {
	private Rigidbody2D rigid;
	private Transform transf;
	public float velocityFactor;

	public static float swipeMinimumDistance = 5f;
	private bool isSwipeCheckStarted = false;
	private bool isSwipeCheckFinalized = false;
	private bool isSwipeCheckUsed = false;
	private Vector2 swipeStart;
	private string swipeResult = null;

	private Vector2 cameraReference = Vector2.zero;

	public float swipeCooldown;
	private float swipeTime = 0f;
	private bool isSwipeInCooldown = false;
		
	void Start () {
		rigid = this.GetComponent<Rigidbody2D>();
		transf = this.GetComponent<Transform>();

		cameraReference.y = Camera.main.orthographicSize;
		cameraReference.x = Camera.main.orthographicSize * ((float) Screen.width / (float) Screen.height);
	}

	Vector2 checkInput(){
		Vector2 inputs = Vector2.zero;

		// checking left swipe/key
		if (Input.GetKeyDown("left") || (isSwipeCheckFinalized && !isSwipeCheckUsed && swipeResult == "left")){
			float leftMult = (transf.position.x + cameraReference.x)/(2*cameraReference.x);
			inputs += Vector2.left * leftMult;
		}

		// checking right swipe/key
		if (Input.GetKeyDown("right") || (isSwipeCheckFinalized && !isSwipeCheckUsed && swipeResult == "right")){
			float rightMult = (2*cameraReference.x - (transf.position.x + cameraReference.x))/(2*cameraReference.x);
			inputs += Vector2.right * rightMult;
		}

		// checking up swipe/key
		if (Input.GetKeyDown("up") || (isSwipeCheckFinalized && !isSwipeCheckUsed && swipeResult == "up")){
			float upMult = (2*cameraReference.y - (transf.position.y + cameraReference.y))/(2*cameraReference.y);
			inputs += Vector2.up * upMult;
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

		if (Input.GetMouseButtonUp(0))
			resetSwipeCheck();
		
	}

	void resetSwipeCheck(){
		isSwipeCheckStarted = false;
			isSwipeCheckFinalized = false;
			isSwipeCheckUsed = false;
			swipeResult = null;
			Debug.Log("swipe reset");
	}

	void addVelocity(Vector2 inputs){
		Vector2 newVelocity = inputs * velocityFactor;
		rigid.velocity = newVelocity;
	}
	
	void Update () {
		if (isSwipeInCooldown){
			resetSwipeCheck();

			swipeTime += Time.deltaTime;
			if (swipeTime >= swipeCooldown) isSwipeInCooldown = false; 
		} else {
			checkSwipe();

			Vector2 inputs = checkInput();
			if (inputs != Vector2.zero){
				addVelocity(inputs);

				isSwipeInCooldown = true;
				swipeTime = 0f;
			}
		}	
	}
}
