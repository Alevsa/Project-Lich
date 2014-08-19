using UnityEngine;
using System.Collections;

public class LionCannon : Weapon {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	override public void Fire ()
	{
		Instantiate (projectile, this.transform.position, Quaternion.identity);
	}
}
