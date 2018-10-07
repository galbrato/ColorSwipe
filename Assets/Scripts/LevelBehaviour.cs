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
        timer = 0;
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
