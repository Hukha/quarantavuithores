using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour {

	public TextMeshProUGUI quelysText, bottlesText, pointsText;

	void Update () {
		if (PlayerManager.player != null) {
			quelysText.SetText (PlayerManager.player.quelys.ToString());
			bottlesText.SetText (PlayerManager.player.bottles.ToString());
			pointsText.SetText (PlayerManager.player.points.ToString());
		}
	}
	public void SelectHand () {
		Debug.Log ("Hand Selected");
		PlayerManager.player.selectedTool = GameData.hand;
	}
	public void SelectFist () {
		Debug.Log ("Fist Selected");
		PlayerManager.player.selectedTool = GameData.fist;
	}

}