using UnityEngine;
using System.Collections;

public class ShieldGenerator : Weapon
{
    private GameObject shieldClone;
    private bool firing;

	// Use this for initialization
	void Start ()
    {
        firingPosition = GameObject.Find("WeaponSlot8");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (firing)
        {
            Ammo -= Time.deltaTime;
        }

        if (Ammo <= 0)
        {
            StopFire();
        }

        if (shieldClone == null)
        {
            firing = false;
        }
	}

    public override void Fire()
    {
        if (shieldClone == null && Ammo > 0)
        {
            shieldClone = GameObject.Instantiate(projectile, firingPosition.transform.position, Quaternion.identity) as GameObject;
            shieldClone.transform.parent = this.transform;
            firing = true;
        }
    }

    public override void StopFire()
    {
        if (shieldClone != null)
            shieldClone.GetComponent<Projectile>().Die();
        firing = false;
    }
}
