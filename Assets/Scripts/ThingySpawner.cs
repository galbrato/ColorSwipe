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

	public Transform thingyCounter;
		
	void Start () {
        float x = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height) + 0.5f;
        float y = Camera.main.orthographicSize - 0.1f;

        transform.position = new Vector3(0f, y);
        transform.localScale = new Vector2(2 * x, 0.1f);

        rend = this.GetComponent<SpriteRenderer>();

		startingPoint = rend.bounds.min;
		offsetRange = rend.bounds.size.x;

        
    }

	void spawnThingy(){
		GameObject newThingy = (GameObject) Instantiate(thingyPrefab, thingyCounter);

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
