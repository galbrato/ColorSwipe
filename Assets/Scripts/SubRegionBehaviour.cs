using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubRegionBehaviour : MonoBehaviour {
    [SerializeField] float TimeToFill = 1;
    float timer;

    SpriteRenderer Effect;
	// Use this for initialization
	void Start () {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        GetComponent<BoxCollider2D>().size = sprite.size;

        SpriteRenderer[] sVector = GetComponentsInChildren<SpriteRenderer>();
        Effect = sVector[1];
        Effect.size = sprite.size;
        timer = 0;
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) StartFill(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));

        if (timer < TimeToFill) {
            timer += Time.deltaTime;
            Effect.transform.localScale = new Vector3(timer/TimeToFill, timer/TimeToFill, 1f);
        } else {
            Effect.transform.localScale = Vector3.zero;
        }
	}

    public void StartFill(Color color) {
        Effect.color = color;
        timer = 0;
    }
}
