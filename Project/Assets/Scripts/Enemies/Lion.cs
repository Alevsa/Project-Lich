using UnityEngine;
using System.Collections;

public class Lion : Enemy {

	// Use this for initialization
	void Start () {
	
	}

	public override void Update () {
		if (Health <= 0)
			Die ();
		
		GetPosition ();
		ChooseDirection ();
		Move ();
	}

	void ChooseDirection () {
		StrafeDown ();
	}
	
}
