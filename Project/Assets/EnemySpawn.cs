using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {

	public float Cooldown;
	public GameObject Set;

	private float TimeSince;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeSince > Cooldown)
		{
			Instantiate (Set, this.transform.position, Quaternion.identity);
			TimeSince = 0;
		}
		else 
			TimeSince += Time.deltaTime;
	}
}
