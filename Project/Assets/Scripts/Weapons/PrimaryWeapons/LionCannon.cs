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
		Instantiate (projectile, firingPosition.transform.position + new Vector3(Random.Range(-0.1F,0.1F), 0,0), Quaternion.identity);
	}
}
