using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingySpawner : MonoBehaviour {

	private SpriteRenderer rend;
	private Vector3 startingPoint;
	private float offsetRange;

	public float timeToSpawn;
	public Object thingyPrefab;
	
	public float velocityFactor;
	private float countTime = 0f;
		
	void Start () {
		rend = this.GetComponent<SpriteRenderer>();
		startingPoint = rend.bounds.min;
		offsetRange = rend.bounds.size.x;
	}

	void spawnThingy(){
		GameObject newThingy = (GameObject) Instantiate(thingyPrefab);
		SpriteRenderer rendThingy = newThingy.GetComponent<SpriteRenderer>();
		Transform transThingy = newThingy.GetComponent<Transform>();
		Rigidbody2D rigidThingy = newThingy.GetComponent<Rigidbody2D>();

		Vector2 thingyPos = new Vector2(startingPoint.x, startingPoint.y) + 
							new Vector2(Random.Range(0f, offsetRange), -rendThingy.bounds.extents.y);

		transThingy.position = new Vector3(thingyPos.x, thingyPos.y, transThingy.position.z);

		Vector2 thingyVelocity = new Vector2(Random.Range(-0.8f, 0.8f), -Random.Range(0.2f, 1f));
		thingyVelocity.Normalize();
		thingyVelocity *= velocityFactor;
		Debug.Log(thingyVelocity);

		rigidThingy.velocity = thingyVelocity;

		Debug.Log("thingy spawned!");
	}
	
	void Update () {
		countTime += Time.deltaTime;

		if (countTime >= timeToSpawn){
			spawnThingy();
			countTime = 0f;
		}
	}
}
