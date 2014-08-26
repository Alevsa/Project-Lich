using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {

	public float Cooldown;
	public GameObject SetOne;
	public GameObject SetTwo;

	public GameObject SpawnTopLeft;
	public GameObject SpawnTopRight;

	private float TimeSince;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeSince > Cooldown)
		{
			if (Random.value > 0.2)
				Instantiate (SetOne, this.transform.position + new Vector3(Random.Range (-2, 2), 0, 0), Quaternion.identity);
			else
				StartCoroutine(SpawnWavecutters());
			TimeSince = 0;
		}
		else 
			TimeSince += Time.deltaTime;
	}

	IEnumerator SpawnWavecutters () {
		InvokeRepeating ("SpawnWavecutter", 0.3F, 0.3F);
		yield return new WaitForSeconds (3F);
		CancelInvoke ("SpawnWavecutter");
	}
	
	void SpawnWavecutter() 
    {
			Instantiate (SetTwo, SpawnTopLeft.transform.position + new Vector3(0, Random.Range (-1, 3), 0), Quaternion.identity);
	}
}
