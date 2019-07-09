using UnityEngine;
using System.Collections;

public class BaseScene : Node
{
	public GameObject gameData;

    protected override void OnAwake ()
	{
		base.OnAwake ();
		//Enables GameData
		gameData = GameObject.Find ("GameData");
		if (gameData == null) {
			Debug.Log ("New Gamedata");
			gameData = GameObject.Instantiate (Resources.Load ("Prefabs/GameController")) as GameObject;
			gameData.name = "GameData";
			DontDestroyOnLoad (gameData);
		}

	}
}
