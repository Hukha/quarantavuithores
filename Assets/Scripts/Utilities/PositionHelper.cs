using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHelper : MonoBehaviour {

	public static int GetPosition (Vector3 currentPosition, Vector3 lastPosition) {
		if (currentPosition.x != lastPosition.x) {
			return currentPosition.x > lastPosition.x ? 2 : 1;
		} else if (currentPosition.y != lastPosition.y) {
			return currentPosition.y > lastPosition.y ? 3 : 0;
		}
		return 3;
	}

	public static Vector3 RandomPositionCloseTo (Vector3 position) {
		float random = Random.Range(-2, 2);
		return new Vector3(RandomNumber(position.x,position.x + random),RandomNumber(position.y,position.y + random),position.z - 3);
	}

	public static float RandomNumber (float min, float max) {
		return Random.Range(min, max);
	}
}