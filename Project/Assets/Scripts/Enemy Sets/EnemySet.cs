﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySet : MonoBehaviour {

	public int Difficulty;
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
