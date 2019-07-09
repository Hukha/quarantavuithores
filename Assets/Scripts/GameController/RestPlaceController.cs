using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestPlaceController : MonoBehaviour {

    public RestPlace restPlace;

    public PatternRoute touristComming(TouristController _tourist) {
        restPlace.tourist = _tourist;
        restPlace.state = RestState.IsComming;
        return restPlace.touristPattern;
    }

    public PatternRoute enemyComming(EnemyController _enemy) {
        restPlace.enemy = _enemy;
        return restPlace.enemyPattern;
    }

    public void touristArrived() {
        restPlace.state = RestState.Full;
    }

    public void touristLeaves() {
        restPlace.tourist = null;
        restPlace.state = RestState.Empty;
    }

    public void enemyLeaves() {
        restPlace.enemy = null;
    }
}
