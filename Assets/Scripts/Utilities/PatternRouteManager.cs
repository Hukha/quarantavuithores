 using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatternRouteManager : MonoBehaviour {

	public List<PatternRoute> touristRoutes;
	public List<PatternRoute> enemyRoutes;

	public PatternRoute GetTouristRoute (Vector3 origin, Vector3 destiny) {
		for (int i = 0; i < touristRoutes.Count; i++) {
			if (touristRoutes[i].route[0].localPosition == origin && touristRoutes[i].route[touristRoutes[i].route.Count - 1].localPosition == destiny) {
				return touristRoutes[i];
			}
		}
		return null;
	}
}
