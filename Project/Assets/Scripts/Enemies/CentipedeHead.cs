using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CentipedeHead : Enemy {

	public int bodyPartCount;
	private GameObject Player;
	
	private Quaternion startRot;
	private Quaternion targetRot;

	// Use this for initialization
	void Start () {
		bodyPartCount = gameObject.GetComponentsInChildren<CentipedeBody> ().Length;
		Player = GameObject.Find ("Player");
	}

	public override void Update() {
		if (Health <= 0)
			Die ();

		PickPattern ();
		GetRotation ();
		Rotate ();
		Move ();
	}

	public override void Move() {
		transform.Translate (Vector3.up * Time.deltaTime * Speed);
	}

	void GetRotation() {
		startRot = transform.rotation;
	}

	void PickPattern () {
		if (isOutsideTheScreen ())
		{
			targetRot = Target (Player);
			startRot = transform.rotation;
		}
	}

	void Rotate() {
		transform.rotation = Quaternion.Slerp (startRot, targetRot, Time.deltaTime * Speed);
	}

	bool isOutsideTheScreen ()
	{
		Vector3 pos = this.transform.position;

		if (((pos.x > 6) || (pos.x < -6)) || ((pos.y > 6) || (pos.y < -6)))
			return true;
		else
			return false;
	}

	Quaternion Target (GameObject target) {
		Vector3 direction;

		if (target != null)
			direction = target.transform.position - transform.position;
		else
			direction = Vector3.zero - transform.position;

		direction.Normalize ();
		
		float rot_z = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		
		return Quaternion.Euler (0f, 0f, rot_z - 90);
	}

	public override void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.SendMessage("ApplyDamage", Health);
		}
	}

	public void ReduceBodyCount () {
		bodyPartCount--;
	}

	public override void ApplyDamage (int damage) 
	{
		if (bodyPartCount == 0)
			Health -= damage;
	}
}
