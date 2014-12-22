using UnityEngine;
using System.Collections;

public class Rhino : Enemy {

	public Vector3 DefaultPosition;
	private bool isOnPattern;
	private ArrayList pattern;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public override void Update () {
		if ((transform.position == DefaultPosition) && !isOnPattern)
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
				pattern.Add (new Vector3 (-3, -6, 0));
				pattern.Add (new Vector3 (0, -6, 0));
				pattern.Add (new Vector3 (0, 6, 0));
				pattern.Add (new Vector3 (3, 6, 0));
				pattern.Add (new Vector3 (3, -6, 0));
				pattern.Add (new Vector3 (0, -6, 0));
				pattern.Add (new Vector3 (0, 6, 0));
				isOnPattern = true;
				break;

			default:
				break;
		}
	}

	private void ExecutePattern()
	{
//		if (pattern [0] == null) 
//		{
//			isOnPattern = false;
//			return;
//		}
//
//		if (transform.position != pattern[0])

	}



}
