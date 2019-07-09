using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public Level current;
	public LevelState state;
	const int JORNADA_MIN = 480,
		JORNADA_START = 540;

	public int timePassed;
	private float fakemMinuteLength, lengthOfAction;
	public TextMeshProUGUI clock, maintitle;
	public Animator titleMainAnimator;

	void Start () {
		state = LevelState.Playing;
		timePassed = 0;
		current = GameData.actualLevel;
		lengthOfAction = JORNADA_MIN / current.totalTime;
		fakemMinuteLength = 1 / lengthOfAction;
		StartCoroutine ("StartLevel");
	}

	IEnumerator StartLevel () {
		maintitle.SetText ("El dia ha comenzado!");
		yield return new WaitForSeconds (1F);
		maintitle.SetText ("DIA " + GameData.actualLevelIndex) ;
		titleMainAnimator.SetTrigger ("Show");
        yield return new WaitForSeconds (1F);
		titleMainAnimator.SetTrigger ("Hide");
		yield return new WaitForSeconds (0.3F);
		StartCoroutine ("ChangeTime");
	}

	IEnumerator EndLevel () {
		maintitle.SetText ("Fin de la jornada");
		titleMainAnimator.SetTrigger ("Show");
		yield return new WaitForSeconds (1F);
		titleMainAnimator.SetTrigger ("Hide");
		yield return new WaitForSeconds (0.3F);
		state = LevelState.End;
	}

	IEnumerator ChangeTime () {
		while (timePassed < JORNADA_MIN) {
			yield return new WaitForSeconds (fakemMinuteLength);
			timePassed += 1;
			DrawHours ();
		}
		StartCoroutine ("EndLevel");
	}

	void Update () {
		switch (state) {
			case LevelState.End:
                SceneManager.LoadScene("ShopScene", LoadSceneMode.Single);
                break;
		}
	}

	void DrawHours () {
		int total = timePassed + JORNADA_START;
		int minutes = total % 60;
		int hours = (total - minutes) / 60;
		string clockHour = (hours < 10 ? "0" + hours.ToString () : hours.ToString ()) + ":" + (minutes < 10 ? "0" + minutes.ToString () : minutes.ToString ());
		clock.SetText (clockHour);
	}

}