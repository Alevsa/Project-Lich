using UnityEngine;
using System.Collections;

public class LionCannon : Weapon {

	// Use this for initialization
	void Start ()  {
		firingPosition = GameObject.Find("WeaponSlot1");	
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

	override public void Fire ()
	{
		Instantiate (projectile, firingPosition.transform.position, Quaternion.identity);
	}
}
