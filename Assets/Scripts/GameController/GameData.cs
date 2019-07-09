using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : Manager {
	public static int actualLevelIndex;
	public static Level actualLevel;
    public static List<Level> levels;
    public static List<Tool> tools;
	public static Tool hand, fist, fon;

    void Awake () {
        base.Awake();
        actualLevelIndex = 0;
        levels = GetLevels();

        tools = new List<Tool> ();
		hand = new Tool ("Mano", ToolAction.Save);
		fist = new Tool ("Puño", ToolAction.Hit);
		fon = new Tool ("Fona", ToolAction.DoubleHit);

        actualLevel = levels[actualLevelIndex];
    }


    private List<Level> GetLevels() {
        List<Level> levels = new List<Level>();
		levels.Add(new Level (1, 
            new LevelConfig( 1, 4, 1, 3, 5, 5, 10, 3, 1, 3),
            1500, 30));
        levels.Add(new Level(2, 
            new LevelConfig(3, 6, 1, 4, 4, 5, 3, 7, 1, 3 ),
            2000, 60));
        levels.Add(new Level(3, 
            new LevelConfig(4, 8, 3, 6, 3, 4, 5, 5, 2, 7),
            3000, 120));
        return levels;
    }

    internal static void NextLevel() {
        actualLevelIndex++;
        if (actualLevelIndex < levels.Count) {
            actualLevel = levels[actualLevelIndex];
            SpawningPool.Clear(true);
            SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
        }
        else if(actualLevelIndex >= levels.Count){
            SpawningPool.Clear(true);
            SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
        }
    }
}