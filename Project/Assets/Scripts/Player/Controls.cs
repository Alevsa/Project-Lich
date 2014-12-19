using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	
	public float speed;

	private Vector3 movement;
	private Weaponry weaponry;
	private bool weaponOnCooldown;

	// Use this for initialization
	void Start () {
		weaponry = GetComponent<Weaponry> ();
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
		if (Input.GetAxisRaw("Horizontal") < 0)
			StrafeLeft ();

		if (Input.GetAxisRaw("Horizontal") > 0)
			StrafeRight ();

		if (Input.GetAxisRaw("Vertical") > 0)
			StrafeUp ();

		if (Input.GetAxisRaw("Vertical") < 0)
			StrafeDown ();

		if (Input.GetButton ("PrimaryFire"))
			PrimaryFireButton ();

		if (Input.GetButtonUp ("PrimaryFire"))
			StopPrimaryFireButton ();

		if (Input.GetButtonDown ("SecondaryFire"))
			SwitchWeaponButton ();

		if (Input.GetButtonUp ("SecondaryFire"))
			StopSecondaryFireButton ();

		if (Input.GetButtonDown ("Pause"))
			PressedPause ();

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

	void PrimaryFireButton () {
		weaponry.PrimaryFire ();
	}

	void StopPrimaryFireButton() {
		weaponry.StopPrimaryFire ();
	}

	void SwitchWeaponButton() {
		weaponry.SecondaryFire ();
	}

	void StopSecondaryFireButton() {
		weaponry.StopSecondaryFire ();
	}

	void PressedPause() {
		GameObject.Find ("GameController").GetComponent<GameController> ().HandlePause ();
	}
}
