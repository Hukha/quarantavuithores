using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutaTestDenFrancesc : MonoBehaviour {

	public GameObject enemy, tourist;

	public PatternRouteManager routeManager;
	public RestPlaceController restPlace;
	void Start () {
		var tourist_instance = Instantiate (tourist);
		tourist_instance.GetComponent<TouristController> ().Init (new Tourist (TourisType.Girl, "tourist01", 1F, routeManager.touristRoutes[0], restPlace, 2));
		var enemy_instance = Instantiate (enemy);
		enemy_instance.GetComponent<EnemyController> ().Init (new Enemy ("enemy01", 2, 2F, routeManager.enemyRoutes[0], restPlace,1));
	}
}