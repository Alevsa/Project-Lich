using UnityEngine;
using System.Collections;

public class DualLionCannon : Weapon {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        firingPosition = GameObject.Find("WeaponSlot2").transform.position;
        secondFiringPosition = GameObject.Find("WeaponSlot3").transform.position;
	}

    override public void Fire()
    {
        Instantiate(projectile, firingPosition, Quaternion.identity);
        Instantiate(projectile, secondFiringPosition, Quaternion.identity);
    }
}
