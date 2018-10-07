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
            Debug.LogError("ERRO!, Dentro do Level deve haver objetos com scriipts RegionBehaviour");
        }
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
