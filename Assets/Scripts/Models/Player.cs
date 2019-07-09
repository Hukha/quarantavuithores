using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public int currentLevel;
    public int coins, bottles, quelys, points;
    public List<PowerUp> powerups;

    public List<Tool> tools;
    public Tool selectedTool;

    public Player () {
        coins = 100;
        bottles = 0;
        quelys = 0;
        points = 0;
        powerups = new List<PowerUp> ();
        currentLevel = 0;
        tools = new List<Tool> () { GameData.hand, GameData.fist };
        selectedTool = tools[0];
    }

}