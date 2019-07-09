using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level {
	public int number;
	public LevelConfig config;
	public int minPoints;
	public int totalTime;

	public Level (int _number, LevelConfig _config, int _minPoints, int _totalTime) {
		number = _number;
		config = _config;
		minPoints = _minPoints;
		totalTime = _totalTime;
	}
}

public enum LevelState { OnLoad, Start, Playing, End }