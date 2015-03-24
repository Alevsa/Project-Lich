using UnityEngine;
using System.Collections;

public class BackAsteroid : MonoBehaviour {

	public float lowerSize, upperSize;
	
	// Use this for initialization
	void Start () 
	{
		SetSize();
	}
	
	void SetSize()
	{
		float size = Random.Range(lowerSize, upperSize);
		transform.localScale = new Vector3(size, size, 0);
		
		GetComponent<ParentAsteroid> ().Speed *= size;
	}
}
