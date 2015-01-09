using UnityEngine;
using System.Collections;

public class Rhino : Enemy {

	public Vector3 DefaultPosition;
	public float maxPatternPointDistance = 1F;
	private bool isOnPattern;
	private ArrayList pattern;

	private Quaternion startRot;
	private Quaternion targetRot;

	// Use this for initialization
	void Start () {
		pattern = new ArrayList ();
	}
	
	// Update is called once per frame
	public override void Update () {
		if (Spatial.isAcceptableDistance(maxPatternPointDistance, this.transform.position, DefaultPosition) && !isOnPattern)
		{
			GetPattern ();
		}

		ExecutePattern ();
	}

	private void GetPattern()
	{
		int caseSwitch = Random.Range (1, 1);

		switch (caseSwitch) 
		{
			case 1:
				pattern.Add (new Vector3 (-3, -12, 0));
				pattern.Add (new Vector3 (0, -12, 0));
				pattern.Add (new Vector3 (0, 12, 0));
				pattern.Add (new Vector3 (3, 12, 0));
				pattern.Add (new Vector3 (3, -12, 0));
				pattern.Add (new Vector3 (0, -12, 0));
				pattern.Add (new Vector3 (0, 12, 0));
				isOnPattern = true;
				break;

			default:
				break;
		}
	}

	private void ExecutePattern()
	{
		if (pattern.Count == 0) 
		{
			isOnPattern = false;
			return;
		}

		if (!Spatial.isAcceptableDistance(maxPatternPointDistance, this.transform.position, (Vector3)pattern[0]))
		{
			targetRot = Target ((Vector3)pattern [0]);
			GetRotation ();
			Rotate ();
			Move ();
		}
		 else
			pattern.RemoveAt (0);

	}

	void GetRotation() {
		startRot = transform.rotation;
	}

	public override void Move() {
		transform.Translate (Vector3.up * Time.deltaTime * Speed);
	}

	void Rotate()
	{
		transform.rotation = Quaternion.Slerp (startRot, targetRot, Time.deltaTime * Speed);
	}

	public Quaternion Target (Vector3 targPoint)
	{
		Vector3 direction = targPoint - transform.position;
		direction.Normalize ();
		
		float rot_z = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		
		return Quaternion.Euler (0f, 0f, rot_z - 90);
	}

}
