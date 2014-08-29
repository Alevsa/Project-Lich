using UnityEngine;
using System.Collections;

public class CheetahCannon : Weapon 
{

	// Use this for initialization
	void Start () 
    {
        firingPosition = GameObject.Find("WeaponSlot1");
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public override void Fire()
    {
        Instantiate(projectile, firingPosition.transform.position, Quaternion.identity); 
    }
}
