using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemySpawn : MonoBehaviour {

	public float Cooldown;

	public GameObject SpawnTopLeft;
	public GameObject SpawnTopRight;
	public GameObject SpawnerBoundTopLeft;
	public GameObject SpawnerBoundTopRight;
    public GameObject SpawnerTopMid;
	public EnemySet[] enemySets;
	public EnemySet[] sortedSets;
	public GameObject[] liveEnemies;

	private float TimeSinceSpawn;
	private int difficulty = 0;
	private int maxDifficulty = 0;

	// Use this for initialization
	void Start () {
		enemySets = this.GetComponents<EnemySet> ();
		sortedSets = new EnemySet[enemySets.Length];
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.timeSinceLevelLoad / 30) > maxDifficulty) 
		{
			IncreaseDifficulty ();
			difficulty = 0;
		}

		if (TimeSinceSpawn > Cooldown)
		{
			liveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
			SortSetsForDifficulty (maxDifficulty - difficulty);
			Spawn(maxDifficulty - difficulty);
			difficulty = (int)Math.Floor((double)difficulty/2);
			TimeSinceSpawn = 0;
		}
		else 
			TimeSinceSpawn += Time.deltaTime;
	}

	void IncreaseDifficulty() {
		maxDifficulty++;
	}

	void Spawn (int diff) {
		int existingSets = 0;

		foreach (EnemySet set in sortedSets) 
		{
			if (set != null)
				existingSets++;
		}

		int chosenSet = UnityEngine.Random.Range (0, existingSets);
		sortedSets[chosenSet].Spawn (GetSpawnPosition(sortedSets[chosenSet]));
		difficulty += sortedSets[chosenSet].Difficulty;
		}

	Vector3 GetSpawnPosition(EnemySet set)
	{
		Vector3 ret = Vector3.zero;

		if (set.Position == "Top")
			ret = SpawnerBoundTopLeft.transform.position + (SpawnerBoundTopRight.transform.position - SpawnerBoundTopLeft.transform.position) * UnityEngine.Random.value;

		if (set.Position == "TopSide")
			ret = SpawnTopLeft.transform.position + new Vector3(0, UnityEngine.Random.Range (-1F, 3F), 0);

		if (set.Position == "BossTop")
			ret = new Vector3 (0, 12, 0);

		return ret;
	}

	void SortSetsForDifficulty (int diff)
	{
		for (int i = 0; i < sortedSets.Length; i++)
			sortedSets [i] = null;

		int sortLength = 0;

		foreach (EnemySet set in enemySets)
		{
			if (set.Difficulty <= (diff))
			{
				sortedSets[sortLength] = set;
				sortLength++;
			}
		}

		EnemySet tmp;

		for (int i = 0; i < sortLength - 1; i++)
				for (int j = 0; j < sortLength - i - 1; j++)
				{
					if (sortedSets[j].Difficulty < sortedSets[j+1].Difficulty)
					{
						tmp = sortedSets[j+1];
						sortedSets[j+1] = sortedSets[j];
						sortedSets[j] = tmp;
					}
				}
	}

	int EnemyCount (string name)
	{
		int ret = 0;

		foreach (GameObject i in liveEnemies) 
		{
			if (i.name == name + "(Clone)")
				ret++;
		}

		return ret;
	}

}
