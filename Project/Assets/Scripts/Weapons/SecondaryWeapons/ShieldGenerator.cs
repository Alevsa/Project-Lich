using UnityEngine;
using System.Collections;

public class ShieldGenerator : Weapon
{
    private GameObject shieldClone;
    public float TotalEnergy = 5f;
    private bool firing;

	// Use this for initialization
	void Start ()
    {
        firingPosition = GameObject.Find("WeaponSlot1");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (firing)
        {
            TotalEnergy -= Time.deltaTime;
        }

        if (TotalEnergy <= 0)
        {
            StopFire();
            Destroy(this.gameObject);
        }

        if (shieldClone == null)
        {
            firing = false;
        }
	}

    public override void Fire()
    {
        if (shieldClone == null && TotalEnergy > 0)
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
