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
		if (Input.GetKey (KeyCode.A))
			StrafeLeft ();

		if (Input.GetKey (KeyCode.D))
			StrafeRight ();

		if (Input.GetKey (KeyCode.W))
			StrafeUp ();

		if (Input.GetKey (KeyCode.S))
			StrafeDown ();

		if (Input.GetKey (KeyCode.Space))
			PrimaryFireButton ();

		if (Input.GetKeyUp (KeyCode.Space))
			StopPrimaryFireButton ();

		if (Input.GetKeyDown (KeyCode.RightShift))
			SwitchWeaponButton ();

		if (Input.GetKeyUp (KeyCode.RightShift))
			StopSecondaryFireButton ();
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
}
