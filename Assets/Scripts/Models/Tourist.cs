using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tourist {
    public string id;
    public float speed;
    public TouristState state;
    public TouristRouteState routeState;
    public PatternRoute pattern;
    public RestPlaceController restPlace;
    public bool stunned;

    public int perfectReward;
    public TourisType type;
    public Tourist (TourisType type, string _id, float _speed, PatternRoute _pattern, RestPlaceController _restPlace,int _perfectReward) {
        id = _id;
        speed = _speed;
        pattern = _pattern;
        state = TouristState.None;
        routeState = TouristRouteState.None;
        stunned = false;
        restPlace = _restPlace;
        perfectReward = _perfectReward;
    }
}
public enum TouristRouteState { None, ToLounger, OnLounger, OutGood, OutBad }
public enum TouristState { None, Normal, Gamba, Bronceado, Quemado, Dep }
public enum TourisType { Girl, Boy }