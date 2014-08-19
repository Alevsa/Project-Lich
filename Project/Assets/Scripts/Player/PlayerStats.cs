using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {

	public int PlayerID;
	public int Health;
	public int MaxHealth;
	public int Lives;
	public GameObject EquippedWeapon;

	bool invulnerable;

	// Use this for initialization
	void Start () {
		EquippedWeapon = GameObject.Instantiate (EquippedWeapon, this.transform.position, Quaternion.identity) as GameObject;
		EquippedWeapon.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {

		if (Health <= 0)
			Die ();
	}

	void Die () {

	}
}
