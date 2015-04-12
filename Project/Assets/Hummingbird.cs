using UnityEngine;
using System.Collections;

public class Hummingbird : Enemy {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public override void Update () {
		if (Health <= 0)
			Die ();
	}
}
