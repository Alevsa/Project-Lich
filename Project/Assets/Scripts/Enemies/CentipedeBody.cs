using UnityEngine;
using System.Collections;

public class CentipedeBody : Enemy {

	public GameObject previousSection;

	public Quaternion startRot;
	public Quaternion targetRot;

	// Use this for initialization
	void Start () {
	
	}

	public override void Update() {
		if (Health <= 0)
			Die ();

		SetDestination ();
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
		
	void Rotate()
	{
		transform.rotation = Quaternion.Slerp (startRot, targetRot, Time.deltaTime * Speed);
	}


	public override void SetDestination () 
	{
		if (previousSection != null) 
		{
			targetRot = Target (previousSection);
		}
	}

	public Quaternion Target (GameObject obj)
	{
		Vector3 direction = obj.transform.position - transform.position;
		direction.Normalize ();
		
		float rot_z = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		
		return Quaternion.Euler (0f, 0f, rot_z - 90);
	}
}
