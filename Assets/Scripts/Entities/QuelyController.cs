using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuelyController : MonoBehaviour {

	private Animator animator;
	bool clicked;
	void Awake () {
		clicked = false;
		animator = GetComponent<Animator> ();
	}

	void Start () {
		StartCoroutine ("DestroyCountDown");
	}

	IEnumerator DestroyCountDown () {
		yield return new WaitForSeconds (4F);
		Destroy (gameObject);
	}

	IEnumerator DestroyAfterVanish () {
		animator.SetTrigger ("Vanish");
		yield return new WaitForSeconds (.3F);
		Destroy (gameObject);
	}

	void OnMouseDown () {
		if (clicked)
			return;
		clicked = true;
		StopCoroutine ("DestroyCountDown");
		StartCoroutine ("DestroyAfterVanish");
		PlayerManager.player.quelys += 1;
	}
}