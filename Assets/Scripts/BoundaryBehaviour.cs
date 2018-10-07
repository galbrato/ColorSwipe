using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBehaviour : MonoBehaviour {
    public int HSide = 0;
    public int VSide = 0;

    // Use this for initialization
    void Start () {
        float x =  Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height) + 0.5f;
        float y =  Camera.main.orthographicSize + 0.5f;

        transform.position = new Vector3( HSide * x, VSide * y);
        transform.localScale = new Vector2(VSide * 2 * x + HSide, HSide * 2 * y + VSide);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
