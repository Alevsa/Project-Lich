using UnityEngine;
using System.Collections;

public class MeatorSet : EnemySet {

	private Vector3 spawnPoint;
	
	public float SpawnCooldown;
	public float SpawnDuration;
	
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
