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

	private float TimeSinceSpawn;
	private int difficulty;
	private int maxDifficulty;

	// Use this for initialization
	void Start () {
		enemySets = this.GetComponents<EnemySet> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.timeSinceLevelLoad / 60) > maxDifficulty)
			IncreaseDifficulty ();

		if (TimeSinceSpawn > Cooldown)
		{
			Spawn(maxDifficulty);
			TimeSinceSpawn = 0;
		}
		else 
			TimeSinceSpawn += Time.deltaTime;
	}

	void IncreaseDifficulty() {
		maxDifficulty++;
	}

	void Spawn (int diff) {

		switch (diff) 
		{
			case 1:
				SpawnLions (0.5F);
				break;

			case 2:
				SpawnLions (0.5F);
				SpawnWavecutters(0.1F);
				break;

			default:
				SpawnLions (0.5F);
				SpawnWavecutters(0.1F);
				break;
		}

//		EnemySet enemySet = enemySets [Random.Range (0, enemySets.Length)];
//
//		if (enemySet.Position == "Top")
//		{
//			Vector3 TopSpawnPoint = SpawnerBoundTopLeft.transform.position + (SpawnerBoundTopRight.transform.position - SpawnerBoundTopLeft.transform.position) * Random.value;
//			enemySet.Spawn (TopSpawnPoint);
//		} 
//		else if (enemySet.Position == "TopSide")
//		{
//			Vector3 TopSideSpawnPoint = SpawnTopLeft.transform.position;
//			enemySet.Spawn (TopSideSpawnPoint);
//		}
//
//		difficulty += enemySet.Difficulty;
	}

	void SpawnLions (float chance)
	{
		if (chance > Random.value) 
		{
			Vector3 TopSpawnPoint = SpawnerBoundTopLeft.transform.position + (SpawnerBoundTopRight.transform.position - SpawnerBoundTopLeft.transform.position) * Random.value; 
			gameObject.GetComponent<LionSet> ().Spawn (TopSpawnPoint);
		}
	}

	void SpawnWavecutters (float chance)
	{
		if (chance > Random.value)
		{
			Vector3 TopSideSpawnPoint = SpawnTopLeft.transform.position + new Vector3(0, Random.Range (-1, 3), 0);
			gameObject.GetComponent<WavecutterSet> ().Spawn (TopSideSpawnPoint);
		}
	}
}
