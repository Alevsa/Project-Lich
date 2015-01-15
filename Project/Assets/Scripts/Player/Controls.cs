using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	
	public float speed;

	public GameObject PlayerPrefab;
	public int playerNumber = 0;
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
        if(Time.deltaTime != 0)
            transform.position = Vector3.Lerp (transform.position, movement, Time.deltaTime * speed / Length); 
	}

	void GetPosition (){
		movement = transform.position;
	}

	void GetInput () {
		if ((playerNumber == 1) || (playerNumber == 0)) 
		{
			if ((playerNumber == 0) && (!CheckForPlayer (1)))
				playerNumber = 1;

			if ((Input.GetAxisRaw ("Horizontal1") < 0) && (playerNumber == 1))
					StrafeLeft ();

			if ((Input.GetAxisRaw ("Horizontal1") > 0) && (playerNumber == 1))
					StrafeRight ();

			if ((Input.GetAxisRaw ("Vertical1") > 0) && (playerNumber == 1))
					StrafeUp ();

			if ((Input.GetAxisRaw ("Vertical1") < 0) && (playerNumber == 1))
					StrafeDown ();

			if (Input.GetButton ("PrimaryFire1")) {
					PrimaryFireButton ();					
			}

			if (Input.GetButton ("PrimaryFire2"))
				CheckForSecondPlayer ();

			if (Input.GetButtonUp ("PrimaryFire1") && (playerNumber == 1))
					StopPrimaryFireButton ();

			if (Input.GetButtonDown ("SecondaryFire1") && (playerNumber == 1))
					SwitchWeaponButton ();

			if (Input.GetButtonUp ("SecondaryFire1") && (playerNumber == 1))
					StopSecondaryFireButton ();

			if (Input.GetButtonDown ("Pause1") && (playerNumber == 1))
					PressedPause ();
		}

		if ((playerNumber == 2) || (playerNumber == 0))
		{
			if ((Input.GetAxisRaw ("Horizontal2") < 0) && (playerNumber == 2))
				StrafeLeft ();
			
			if ((Input.GetAxisRaw ("Horizontal2") > 0) && (playerNumber == 2))
				StrafeRight ();
			
			if ((Input.GetAxisRaw ("Vertical2") > 0) && (playerNumber == 2))
				StrafeUp ();
			
			if ((Input.GetAxisRaw ("Vertical2") < 0) && (playerNumber == 2))
				StrafeDown ();
			
			if (Input.GetButton ("PrimaryFire2")) {
				PrimaryFireButton ();
				
				if ((playerNumber == 0) && (!CheckForPlayer (2)))
					playerNumber = 2;
			}
			
			if (Input.GetButtonUp ("PrimaryFire2") && (playerNumber == 2))
				StopPrimaryFireButton ();
			
			if (Input.GetButtonDown ("SecondaryFire2") && (playerNumber == 2))
				SwitchWeaponButton ();
			
			if (Input.GetButtonUp ("SecondaryFire2") && (playerNumber == 2))
				StopSecondaryFireButton ();
			
			if (Input.GetButtonDown ("Pause1") && (playerNumber == 2))
				PressedPause ();
		}

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

	bool CheckForPlayer (int number)
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject player in players)
		{
			if (player.GetComponent<Controls>().playerNumber == number)
				return true;
		}

		return false;
	}

	void CheckForSecondPlayer()
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		if (players.Length != 2)
			GameObject.Instantiate (PlayerPrefab, this.transform.position, Quaternion.identity);
	}
}
