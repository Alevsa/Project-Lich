using UnityEngine;
using System.Collections;

public class KameCannon : Weapon 
{
    private GameObject kameClone;
    public float totalEnergy = 5f;
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
            totalEnergy -= Time.deltaTime;

		if (totalEnergy <= 0)
			StopFire ();

        if (kameClone == null)
            firing = false;
	}

    public override void Fire()
    {
        if(kameClone == null && totalEnergy > 0) 
        {
            kameClone = GameObject.Instantiate(projectile, firingPosition.transform.position, Quaternion.identity) as GameObject;
			kameClone.transform.parent = this.transform;
            firing = true;
        }
    }

	public override void StopFire() 
	{
		kameClone.GetComponent<Projectile> ().Die ();
		firing = false;
	}

}
