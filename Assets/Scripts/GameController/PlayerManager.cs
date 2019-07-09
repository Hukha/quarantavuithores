using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
	public static Player player;

	void Start () {
		player = new Player();
	}

	public void GoToLevel(){
		SceneManager.LoadScene ("LevelScene", LoadSceneMode.Single);
	}

}