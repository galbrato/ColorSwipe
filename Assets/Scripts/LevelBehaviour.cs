using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehaviour : MonoBehaviour {
    [SerializeField] float GlowFreq = 0.5f;
    float timer;
    RegionBehaviour[] regions;
	// Use this for initialization
	void Start () {
        regions = GetComponentsInChildren<RegionBehaviour>();
        if (regions.Length < 1) {
            Debug.LogError("ERRO!, Dentro do Level deve haver objetos com scriipts RegionBehaviourwe");
        }
        timer = 0;
        float screenProportion = (float)Screen.width/ (float)Screen.height;
        float x = (1280f/800f) * screenProportion;
        transform.localScale = new Vector3(x, 1);
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > 1/GlowFreq) {
            timer = 0;
            regions[Random.Range(0, regions.Length)].StartFill();
        }
	}
}
