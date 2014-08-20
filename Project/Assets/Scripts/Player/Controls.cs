using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	
	public float speed;

	private bool controlsEnabled = true;
	private Vector3 movement;
	private PlayerStats Stats;
	private bool weaponOnCooldown;

	// Use this for initialization
	void Start () {
		Stats = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetPosition ();
		GetInput ();
		Move ();
	}

	void Move () {
		float Length = Vector3.Distance (transform.position, movement);
		transform.position = Vector3.Lerp (transform.position, movement, Time.deltaTime * speed / Length); 
	}

	void GetPosition (){
		movement = transform.position;
	}

	void GetInput () {
		if (!controlsEnabled)
			return;

		if (Input.GetKey (KeyCode.A))
			StrafeLeft ();

		if (Input.GetKey (KeyCode.D))
			StrafeRight ();

		if (Input.GetKey (KeyCode.W))
			StrafeUp ();

		if (Input.GetKey (KeyCode.S))
			StrafeDown ();

		if (Input.GetKey (KeyCode.Space))
			FireButton ();
	}

	void StrafeLeft () {
		movement += new Vector3 (-speed, 0, 0);
	}

	void StrafeRight () {
		movement += new Vector3 (speed, 0, 0);
	}

	void StrafeUp () {
		movement += new Vector3 (0, speed, 0);
	}

	void StrafeDown () {
		movement += new Vector3 (0, -speed, 0);
	}

	void FireButton () {
		if (!weaponOnCooldown)
		{
			Stats.EquippedWeapon.GetComponent<Weapon>().Fire ();
			weaponOnCooldown = true;
			StartCoroutine(CoolingDown (Stats.EquippedWeapon.GetComponent<Weapon>().Cooldown));
		}
	}

	public void MoveTowards(Vector3 destination)
	{
		movement = destination;
	}

	IEnumerator CoolingDown (float Cooldown) 
	{
		yield return new WaitForSeconds (Cooldown);
		weaponOnCooldown = false;
	}
}
