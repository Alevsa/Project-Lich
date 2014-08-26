using UnityEngine;
using System.Collections;

public class EnemySet : MonoBehaviour {

	public float Difficulty;
	public GameObject Enemy1;
	public string Position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Spawn (Vector3 SpawnPoint) {
	}
}
