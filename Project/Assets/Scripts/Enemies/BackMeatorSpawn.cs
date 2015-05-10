using UnityEngine;
using System.Collections;
using System;

public class BackMeatorSpawn : MonoBehaviour {

	public GameObject[] Meators;
	public float Cooldown;
	public float SpawnChance;
	
	private float timeSinceLastSpawn;
	private float timeSinceLastCheck;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timeSinceLastCheck > Cooldown) {
			if (isSpawning())
			{
				int j = UnityEngine.Random.Range(0, 11);

				GameObject.Instantiate (Meators[j], this.transform.position + new Vector3 (UnityEngine.Random.Range (-8F, 8F), 0, 0), Quaternion.identity);
				timeSinceLastSpawn = 0;
			}
			timeSinceLastCheck = 0;
			timeSinceLastSpawn += Time.deltaTime;
		}
		else
		{
			timeSinceLastCheck += Time.deltaTime;
			timeSinceLastSpawn += Time.deltaTime;
		}
	}
	
	bool isSpawning () 
	{
		if (((UnityEngine.Random.Range (0F, 1F) / Math.Sqrt (timeSinceLastSpawn)) * 10) <= (SpawnChance / 100))
			return true;
		else
			return false;
	}
}
