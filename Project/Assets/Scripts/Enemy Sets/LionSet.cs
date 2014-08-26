using UnityEngine;
using System.Collections;

public class LionSet : EnemySet {

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
		StartCoroutine (BeginSpawn());
	}

	IEnumerator BeginSpawn() {
		InvokeRepeating ("SpawnEnemy", SpawnCooldown, SpawnCooldown);
		yield return new WaitForSeconds (SpawnDuration);
		CancelInvoke ("SpawnEnemy");
	}
	
	void SpawnEnemy () {
		Instantiate (Enemy1, spawnPoint, Quaternion.identity);
	}
}
