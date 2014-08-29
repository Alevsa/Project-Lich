using UnityEngine;
using System.Collections;

public class DualCheetahGun : Weapon {

    private GameObject secondFiringPosition;

	// Use this for initialization
	void Start () {

        firingPosition = GameObject.Find("WeaponSlot4");
        secondFiringPosition = GameObject.Find("WeaponSlot5");	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    override public void Fire()
    {
        Instantiate(projectile, firingPosition.transform.position, Quaternion.identity);
        Instantiate(projectile, secondFiringPosition.transform.position, Quaternion.identity);
    }
}
