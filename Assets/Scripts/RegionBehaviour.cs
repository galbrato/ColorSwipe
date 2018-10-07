using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionBehaviour : MonoBehaviour {

    SubRegionBehaviour[] subRegions;
	// Use this for initialization
	void Start () {
        subRegions = GetComponentsInChildren<SubRegionBehaviour>();
        if(subRegions.Length < 1) {
            Debug.LogError("ERRO!, Dentro do Region deve haver objetos com scripts SubRegionBehaviour");
        }
	}
	
    public void StartFill() {
        Color c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        foreach (SubRegionBehaviour item in subRegions) { 
            item.StartFill(c);
        }
    }
}
