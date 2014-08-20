using UnityEngine;
using System.Collections;

public class LionCannon : Weapon {

	// Use this for initialization
	void Start ()  {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        firingPosition = GameObject.Find("WeaponSlot1").transform.position;
	}

	override public void Fire ()
	{
		Instantiate (projectile, firingPosition, Quaternion.identity);
	}
}
