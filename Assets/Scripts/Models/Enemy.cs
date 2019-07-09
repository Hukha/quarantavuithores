using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Enemy {
	public string id;
	public int health, currentHealth;
	public float speed;
	public PatternRoute pattern;
	public EnemyState state;
	public EnemyAction action;
	public RestPlaceController target;

	public int rewardBeforeStunt;
	public EnemyType type;

	public void TakeHealth (int value) {
		if (currentHealth - value > 0) {
			currentHealth -= value;
		} else {
			state = EnemyState.Dead;
			currentHealth = 0;
		}
	}
	public Enemy (string _id, int _health, float _speed, PatternRoute _route, RestPlaceController _target,int rewards) {
		id = _id;
		health = _health;
		currentHealth = _health;
		speed = _speed;
		target = _target;
		pattern = _route;
		state = EnemyState.Alive;
		action = EnemyAction.None;
		rewardBeforeStunt = rewards;
	}

}

public enum EnemyState { Alive, AfterHit, Dead }
public enum EnemyAction { None, ToTarget, OnTarget, ToDestiny }

public enum EnemyType { Farmer, Drunk }
