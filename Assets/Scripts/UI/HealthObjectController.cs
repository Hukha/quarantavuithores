using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObjectController : MonoBehaviour {

	private bool state;

	void Start(){
		state = true;
	}

	public void Enable(){
		if(!state){
			state = true;
			GetComponent<Animator>().SetTrigger("Enable");
		}
	}
	public void Disable(){
		if(state){
			state = false;
			GetComponent<Animator>().SetTrigger("Disable");
		}
	}
}
