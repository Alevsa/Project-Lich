using UnityEngine;
using System.Collections;

public class SprayEnemy : Enemy {

	public float yDisplace, timeBeforeMove;
	private float timer;
	private Vector3 moveLoc;
	private bool notFired;
	private Spinner spinner;
	// Use this for initialization
	void Start () {
		Spinner = GetComponentInChildren<Spinner> ();
		moveInfrontPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > timeBeforeMove) 
		{
			moveInfrontPlayer ();
			timer = 0f;
		}

		if(moveLoc != transform.position)
			transform.position = Vector3.MoveTowards (transform.position, moveLoc, Speed * Time.deltaTime);

		if (moveLoc == transform.position && notFired)
			sprayFire ();
	}

	private void moveInfrontPlayer()
	{
		Vector3 playerPos = GameObject.Find("Player").transform.position;
		moveLoc = playerPos - new Vector3 (0, yDisplace);
		notFired = true;
	}

	private void sprayFire()
	{
		notFired = false;
		spinner.startFire ();
	}
}
