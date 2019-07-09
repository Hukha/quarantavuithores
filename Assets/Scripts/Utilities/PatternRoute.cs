using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternRoute : MonoBehaviour {

	public string id;
	public List<Transform> route;
	
	void Awake(){
		gameObject.name = id;
	}

    public List<Vector3> GetPatternVectors() {
        return route.Select(t => t.position).ToList();
    }

    public List<Vector3> GetPatternVectorsReversed() {
        return route.AsEnumerable().Reverse().Select(t => t.position).ToList();
    }
}

