﻿using UnityEngine;
using System.Collections;

public class LionProjectile : Projectile {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public override void Update () {
		GetPosition ();
		StrafeUp ();
		Move ();
        DestroyAfterTime();
	}
}
