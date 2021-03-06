﻿using UnityEngine;
using System.Collections;

public class TargetPlayerOnSpawn : MonoBehaviour {
	
	public float Speed;
	
	private GameObject Player;
	
	private Quaternion startRot;
	private Quaternion targetRot;
	
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		GetRotation ();
		targetRot = Target (Player);
		Rotate ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Rotate() {
		transform.rotation = targetRot;
	}
	
	void GetRotation() {
		startRot = transform.rotation;
	}
	
	Quaternion Target (GameObject target) {
		Vector3 direction;
		
		if (target != null)
			direction = target.transform.position - transform.position;
		else
			direction = Vector3.zero - transform.position;
		
		direction.Normalize ();
		
		float rot_z = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		
		return Quaternion.Euler (0f, 0f, rot_z - 90);
	}
}
