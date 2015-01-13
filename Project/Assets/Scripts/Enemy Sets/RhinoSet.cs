using UnityEngine;
using System.Collections;

public class RhinoSet : EnemySet {

	private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Spawn (Vector3 SpawnPoint)
	{
		spawnPoint = SpawnPoint;
		GameObject.Instantiate (Enemy1, spawnPoint, Quaternion.identity);
	}
}
