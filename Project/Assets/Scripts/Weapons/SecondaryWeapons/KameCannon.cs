using UnityEngine;
using System.Collections;

public class KameCannon : Weapon 
{
    private GameObject kameClone;
    private bool firing;

	// Use this for initialization
	void Start () {
        firingPosition = GameObject.Find("WeaponSlot1");	
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
            Ammo = 0;
			StopFire ();
		}

        if (kameClone == null)
        {
            firing = false;
            GetComponent<AudioSource>().Stop();
        }
	}

    public override void Fire()
    {
        if(kameClone == null && Ammo > 0) 
        {
            kameClone = GameObject.Instantiate(projectile, firingPosition.transform.position, Quaternion.identity) as GameObject;
			kameClone.transform.parent = this.transform;
            firing = true;
            GetComponent<AudioSource>().Play();
        }
    }

	public override void StopFire() 
	{
		if (kameClone != null)
			Destroy(kameClone);
		firing = false;
	}

}
