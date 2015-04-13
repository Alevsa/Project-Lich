using UnityEngine;
using System.Collections;

public class SprayEnemy : Enemy {

	public float timeBeforeMove;
	private float timer, yDisplace;
	private Vector3 moveLoc;
	private bool notFired;
	private Spinner spinner;
	private GameObject bounds;
	// Use this for initialization
	void Start () {
		spinner = GetComponentInChildren<Spinner> ();
		bounds = GameObject.Find ("PlayerBoundUp");
		moveInfrontPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(moveLoc != transform.position)
			transform.position = Vector3.MoveTowards (transform.position, moveLoc, Speed * Time.deltaTime);
		
		if (moveLoc == transform.position && notFired)
			sprayFire ();
	}
	
	public void moveInfrontPlayer()
	{
		yDisplace = Random.Range (-2, -8);
		Vector3 playerPos = GameObject.Find("Player").transform.position;
		moveLoc = playerPos - new Vector3 (0, yDisplace);
		if (moveLoc.y > bounds.transform.position.y)
			moveLoc.y = bounds.transform.position.y - 2;
		notFired = true;
	}
	
	private void sprayFire()
	{
		notFired = false;
		spinner.startFire ();
	}

}
