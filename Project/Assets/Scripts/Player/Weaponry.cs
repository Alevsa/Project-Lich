using UnityEngine;
using System.Collections;

public class Weaponry : MonoBehaviour {

	public GameObject PrimaryWeapon;
	public GameObject SecondaryWeapon;
	private Controls playerControls;
	private int BelongsToPlayer;

	// Use this for initialization
	void Start () 
    {
		playerControls = gameObject.GetComponent<Controls> ();
		BelongsToPlayer = playerControls.playerNumber;

        if (PrimaryWeapon != null)
        {
            PrimaryWeapon = GameObject.Instantiate(PrimaryWeapon, this.transform.position, Quaternion.identity) as GameObject;
            PrimaryWeapon.transform.parent = gameObject.transform;
			PrimaryWeapon.GetComponent<Weapon>().BelongsToPlayer = BelongsToPlayer;
			PrimaryWeapon.GetComponent<Weapon>().unbound = true;
        }

        if (SecondaryWeapon != null)
        {
            SecondaryWeapon = GameObject.Instantiate(SecondaryWeapon, this.transform.position, Quaternion.identity) as GameObject;
            SecondaryWeapon.transform.parent = gameObject.transform;
			SecondaryWeapon.GetComponent<Weapon>().BelongsToPlayer = BelongsToPlayer;
			SecondaryWeapon.GetComponent<Weapon>().unbound = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (playerControls != null)
			BelongsToPlayer = playerControls.playerNumber;

		PrimaryWeapon.GetComponent<Weapon>().BelongsToPlayer = BelongsToPlayer;
		PrimaryWeapon.GetComponent<Weapon>().unbound = true;
		SecondaryWeapon.GetComponent<Weapon>().BelongsToPlayer = BelongsToPlayer;
		SecondaryWeapon.GetComponent<Weapon>().unbound = true;
	}

	public void ChangeWeapon (GameObject weapon) {
		if (weapon.GetComponent<Weapon> ().Type == "Primary")
		{
            if (PrimaryWeapon.GetComponent<Weapon>().Group == weapon.GetComponent<Weapon>().Group)
                    weapon = (PrimaryWeapon.GetComponent<Weapon>().Upgrade);

            if (weapon != null)
            {
                Destroy(PrimaryWeapon);
                PrimaryWeapon = GameObject.Instantiate(weapon, this.transform.position, Quaternion.identity) as GameObject;
                PrimaryWeapon.transform.parent = gameObject.transform;
				PrimaryWeapon.GetComponent<Weapon>().BelongsToPlayer = BelongsToPlayer;
            }
		} 
		else if (weapon.GetComponent<Weapon>().Type == "Secondary")
		{
			Destroy (SecondaryWeapon);
			SecondaryWeapon = GameObject.Instantiate (weapon, this.transform.position, Quaternion.identity) as GameObject;
			SecondaryWeapon.transform.parent = gameObject.transform;
			SecondaryWeapon.GetComponent<Weapon>().BelongsToPlayer = BelongsToPlayer;
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
