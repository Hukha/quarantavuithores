using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeController : MonoBehaviour {

	public TextMeshProUGUI pointsText, quelyText, bottlesText, totalText;

	void Start () {
		if (PlayerManager.player != null) {
			pointsText.SetText (PlayerManager.player.points.ToString ());
			int total = PlayerManager.player.points + (PlayerManager.player.quelys * 20) + (PlayerManager.player.bottles * 100);
			totalText.SetText (total.ToString ());
			int pointsforQuelys = 20 * PlayerManager.player.quelys;
			quelyText.SetText (pointsforQuelys > 0 ? "[x" + PlayerManager.player.quelys.ToString () + "] " + pointsforQuelys.ToString () : "0");
			int pointsforBottles = 20 * PlayerManager.player.bottles;
			bottlesText.SetText (pointsforBottles > 0 ? "[x" + PlayerManager.player.bottles.ToString () + "] " + pointsforBottles.ToString () : "0");
		}else{
			Debug.Log("ERROR!");
		}
	}

	public void GoToMenu(){
		SceneManager.LoadScene ("StartScene", LoadSceneMode.Single);
    }

    public void GoToNextLevel() {
        GameData.NextLevel();
    }


}