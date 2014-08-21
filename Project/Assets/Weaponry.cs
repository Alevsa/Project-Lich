using UnityEngine;
using System.Collections;

public class Weaponry : MonoBehaviour {

	public GameObject MainWeapon;
	public GameObject TempWeapon;
	public GameObject ActiveWeapon;

	// Use this for initialization
	void Start () {
		MainWeapon = GameObject.Instantiate (MainWeapon, this.transform.position, Quaternion.identity) as GameObject;
		ActiveWeapon = MainWeapon;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeWeapon (GameObject weapon) {
		if (weapon.GetComponent<Weapon> ().Type == "Main") {
			Destroy (MainWeapon);
			MainWeapon = GameObject.Instantiate (weapon, this.transform.position, Quaternion.identity) as GameObject;
			MainWeapon.transform.parent = gameObject.transform;
		} 
		else
		{
			Destroy (TempWeapon);
			TempWeapon = GameObject.Instantiate (weapon, this.transform.position, Quaternion.identity) as GameObject;
			TempWeapon.transform.parent = gameObject.transform;
		}
	}

	public void Fire () {
		if (ActiveWeapon != null)
		{
			if (!ActiveWeapon.GetComponent<Weapon> ().onCooldown)
			{
				ActiveWeapon.GetComponent<Weapon> ().Fire ();
				StartCoroutine (CoolingDown (ActiveWeapon.GetComponent<Weapon> (), ActiveWeapon.GetComponent<Weapon> ().Cooldown));
			}
		} 
		else
			SwitchWeapons ();
	}
	
	public void StopFire () {
		if (ActiveWeapon != null)
			ActiveWeapon.GetComponent<Weapon> ().StopFire ();
	}
	
	public void SwitchWeapons () {
		if ((TempWeapon != null) && (ActiveWeapon == MainWeapon))
		{
			StopFire ();
			ActiveWeapon = TempWeapon;
		} 
		else if ((MainWeapon != null) && (ActiveWeapon == TempWeapon))
		{
			StopFire ();
			ActiveWeapon = MainWeapon;
		}
	}
	
	IEnumerator CoolingDown (Weapon weapon, float Cooldown) 
	{
		weapon.onCooldown = true;
		yield return new WaitForSeconds (Cooldown);
		weapon.onCooldown = false;
	}
}
