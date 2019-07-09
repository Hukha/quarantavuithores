using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public PowerUpType type;
	public int power;

	public PowerUp (PowerUpType _type, int _power) {
		type = _type;
		power = _power;
	}
}

public enum PowerUpType { MoreQuelis, SlowEnemies, MoreDamage }