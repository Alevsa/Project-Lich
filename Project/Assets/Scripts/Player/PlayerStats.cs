using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {

	public int PlayerID;
	public int Health;
	public int MaxHealth;
	public int Lives;
	public GameObject EquippedWeapon;
	public GameObject TempWeapon;

	bool invulnerable;

	// Use this for initialization
	void Start () {
		EquippedWeapon = GameObject.Instantiate (EquippedWeapon, this.transform.position, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (Health <= 0)
			Die ();
	}

	void Die () {
		Destroy (this.gameObject);
		Application.Quit ();
	}

	public void ChangeWeapon (GameObject weapon) {
		if (weapon.GetComponent<Weapon> ().Type == "Main") {
			Destroy (EquippedWeapon);
			EquippedWeapon = GameObject.Instantiate (weapon, this.transform.position, Quaternion.identity) as GameObject;
			EquippedWeapon.transform.parent = gameObject.transform;
		} 
		else
		{
			Destroy (TempWeapon);
			TempWeapon = GameObject.Instantiate (weapon, this.transform.position, Quaternion.identity) as GameObject;
			TempWeapon.transform.parent = gameObject.transform;
		}
	}

	void ApplyDamage (int damage) {
		Health -= damage;
	}

	public void Fire () {
		if (TempWeapon != null)
		{
			if (!TempWeapon.GetComponent<Weapon> ().onCooldown)
			{
				TempWeapon.GetComponent<Weapon> ().Fire ();
				StartCoroutine (CoolingDown (TempWeapon.GetComponent<Weapon> (), TempWeapon.GetComponent<Weapon> ().Cooldown));
			}
		}
		else
		{
			if (!EquippedWeapon.GetComponent<Weapon>().onCooldown)
			{
				EquippedWeapon.GetComponent<Weapon>().Fire ();
				StartCoroutine (CoolingDown (EquippedWeapon.GetComponent<Weapon>(), EquippedWeapon.GetComponent<Weapon>().Cooldown));
			}
		}
	}

	public void StopFire () {
		if (TempWeapon != null)
		{
			TempWeapon.GetComponent<Weapon> ().StopFire ();
		} 
		else
		{
			EquippedWeapon.GetComponent<Weapon>().StopFire();
		}
	}

	IEnumerator CoolingDown (Weapon weapon, float Cooldown) 
	{
		weapon.onCooldown = true;
		yield return new WaitForSeconds (Cooldown);
		weapon.onCooldown = false;
	}

}
