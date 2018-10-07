using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionBehaviour : MonoBehaviour {

    SubRegionBehaviour[] subRegions;
	// Use this for initialization
	void Start () {
        subRegions = GetComponentsInChildren<SubRegionBehaviour>();
	}
	
    public void StartFill() {
        Color c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        foreach (SubRegionBehaviour item in subRegions) { 
            item.StartFill(c);
        }
    }
}
