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
		ChangeWeapon (EquippedWeapon);
	}
	
	// Update is called once per frame
	void Update () {

		if (Health <= 0)
			Die ();
	}

	void Die () {
		if (Lives == 0) 
		{
			EndGame();
		}

		Lives--;
		Respawn ();
	}

	void EndGame() {
		Destroy (this.gameObject);
	}

	void Respawn() {
		this.transform.position = new Vector3 (this.transform.position.x, -4, -1);
		Health = MaxHealth;
		StartCoroutine (RespawnRoutine ());
	}

	IEnumerator RespawnRoutine()
	{
		SetInvulnerability (true);
		yield return new WaitForSeconds(3.0f);
		SetInvulnerability(false);
	}

	void SetInvulnerability (bool value)
	{
		invulnerable = value;
		collider2D.enabled = !value;
	}

	public void ChangeWeapon (GameObject weapon) {
		DestroyImmediate (EquippedWeapon, false);
		EquippedWeapon = GameObject.Instantiate (weapon, this.transform.position, Quaternion.identity) as GameObject;
		EquippedWeapon.transform.parent = gameObject.transform;
	}

	void ApplyDamage (int damage) {
		if (!invulnerable)
			Health -= damage;
	}

}
