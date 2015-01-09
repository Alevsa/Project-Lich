using UnityEngine;
using System.Collections;

public static class Spatial {

	public static bool isAcceptableDistance (float distance, Vector3 bodyOne, Vector3 bodyTwo)
	{
		if (Vector3.Distance (bodyOne, bodyTwo) < distance)
			return true;
		else
			return false;
	}
}
