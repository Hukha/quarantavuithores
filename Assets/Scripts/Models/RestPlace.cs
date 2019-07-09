using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RestPlace {
    public int id;
    public TouristController tourist;
    public EnemyController enemy;
    public RestState state;
    public PatternRoute touristPattern;
    public PatternRoute enemyPattern;
    public bool orientation;


    public RestPlace(int _id) {
        id = _id;
        state = RestState.Empty;
    }
}
public enum RestState { Empty, IsComming, Full }
