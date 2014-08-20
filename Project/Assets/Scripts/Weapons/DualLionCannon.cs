using UnityEngine;
using System.Collections;

public class DualLionCannon : Weapon {

	public GameObject secondFiringPosition;

	// Use this for initialization
	void Start () {
		firingPosition = GameObject.Find("WeaponSlot2");
		secondFiringPosition = GameObject.Find("WeaponSlot3");	
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    override public void Fire()
    {
        Instantiate(projectile, firingPosition.transform.position, Quaternion.identity);
        Instantiate(projectile, secondFiringPosition.transform.position, Quaternion.identity);
    }
}
