using UnityEngine;
using System.Collections;

public class Weaponry : MonoBehaviour {

	public GameObject PrimaryWeapon;
	public GameObject SecondaryWeapon;

	// Use this for initialization
	void Start () {
		PrimaryWeapon = GameObject.Instantiate (PrimaryWeapon, this.transform.position, Quaternion.identity) as GameObject;
		PrimaryWeapon.transform.parent = gameObject.transform;

		SecondaryWeapon = GameObject.Instantiate (SecondaryWeapon, this.transform.position, Quaternion.identity) as GameObject;
		SecondaryWeapon.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeWeapon (GameObject weapon) {
		if (weapon.GetComponent<Weapon> ().Type == "Primary")
		{
			Destroy (PrimaryWeapon);
			PrimaryWeapon = GameObject.Instantiate (weapon, this.transform.position, Quaternion.identity) as GameObject;
			PrimaryWeapon.transform.parent = gameObject.transform;
		} 
		else if (weapon.GetComponent<Weapon>().Type == "Secondary")
		{
			Destroy (SecondaryWeapon);
			SecondaryWeapon = GameObject.Instantiate (weapon, this.transform.position, Quaternion.identity) as GameObject;
			SecondaryWeapon.transform.parent = gameObject.transform;
		}
	}

	public void PrimaryFire () {
		if (PrimaryWeapon != null)
		{
			if (!PrimaryWeapon.GetComponent<Weapon>().onCooldown)
			{
				PrimaryWeapon.GetComponent<Weapon> ().Fire ();
				StartCoroutine (CoolingDown (PrimaryWeapon.GetComponent<Weapon> (), PrimaryWeapon.GetComponent<Weapon> ().Cooldown));
			}
		}
	}
	
	public void StopPrimaryFire () {
		if (PrimaryWeapon != null)
			PrimaryWeapon.GetComponent<Weapon> ().StopFire ();
	}

	public void SecondaryFire() {
		if (SecondaryWeapon != null)
		{
			if (!SecondaryWeapon.GetComponent<Weapon>().onCooldown)
			{
				SecondaryWeapon.GetComponent<Weapon> ().Fire ();
				StartCoroutine (CoolingDown (SecondaryWeapon.GetComponent<Weapon> (), SecondaryWeapon.GetComponent<Weapon> ().Cooldown));
			}
		} 
	}

	public void StopSecondaryFire () {
		if (SecondaryWeapon != null)
			SecondaryWeapon.GetComponent<Weapon> ().StopFire ();
	}

	public void UpgradeWeapon () {
		ChangeWeapon (PrimaryWeapon.GetComponent<Weapon> ().Upgrade);
	}
	
	IEnumerator CoolingDown (Weapon weapon, float Cooldown) 
	{
		weapon.onCooldown = true;
		yield return new WaitForSeconds (Cooldown);
		weapon.onCooldown = false;
	}
}
