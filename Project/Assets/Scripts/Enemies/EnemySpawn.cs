using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {

	public float Cooldown;

	public GameObject SpawnTopLeft;
	public GameObject SpawnTopRight;
	public GameObject SpawnerBoundTopLeft;
	public GameObject SpawnerBoundTopRight;
	public EnemySet[] enemySets;

	private float TimeSince;

	// Use this for initialization
	void Start () {
		enemySets = this.GetComponents<EnemySet> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeSince > Cooldown)
		{
			SpawnSomething();
			TimeSince = 0;
		}
		else 
			TimeSince += Time.deltaTime;
	}

	void SpawnSomething() {
		EnemySet enemySet = enemySets [Random.Range (0, enemySets.Length)];

		if (enemySet.Position == "Top")
		{
			Vector3 TopSpawnPoint = SpawnerBoundTopLeft.transform.position + (SpawnerBoundTopRight.transform.position - SpawnerBoundTopLeft.transform.position) * Random.value;
			enemySet.Spawn (TopSpawnPoint);
		} 
		else if (enemySet.Position == "TopSide")
		{
			Vector3 TopSideSpawnPoint = SpawnTopLeft.transform.position;
			enemySet.Spawn (TopSideSpawnPoint);
		}
	}
}
