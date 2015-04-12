using UnityEngine;
using System.Collections;

public class HummingBlaster : Weapon {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Fire() 
	{
		GameObject.Instantiate (projectile, this.transform.position, Quaternion.identity);
	}
}
