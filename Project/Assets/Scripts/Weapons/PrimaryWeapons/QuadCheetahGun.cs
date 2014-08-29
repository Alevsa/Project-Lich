using UnityEngine;
using System.Collections;

public class QuadCheetahGun : Weapon {

    private GameObject secondFiringPosition, thirdFiringPosition, fourthFiringPosition;

	// Use this for initialization
	void Start () {

        firingPosition = GameObject.Find("WeaponSlot2");
        secondFiringPosition = GameObject.Find("WeaponSlot3");
        thirdFiringPosition = GameObject.Find("WeaponSlot4");
        fourthFiringPosition = GameObject.Find("WeaponSlot5");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    override public void Fire()
    {
        Instantiate(projectile, firingPosition.transform.position, Quaternion.identity);
        Instantiate(projectile, secondFiringPosition.transform.position, Quaternion.identity);
        Instantiate(projectile, thirdFiringPosition.transform.position, Quaternion.identity);
        Instantiate(projectile, fourthFiringPosition.transform.position, Quaternion.identity);
    }
}
