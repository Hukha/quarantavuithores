using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleController : MonoBehaviour {

	private Animator animator;
	bool clicked;
	void Awake () {
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
		Destroy (gameObject);
		yield return null;
	}

	void OnMouseDown () {
		if (clicked)
			return;
		clicked = true;
		StopCoroutine ("DestroyCountDown");
		StartCoroutine ("DestroyAfterVanish");
		PlayerManager.player.bottles += 1;
	}
}