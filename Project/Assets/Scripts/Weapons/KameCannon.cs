using UnityEngine;
using System.Collections;

public class KameCannon : Weapon 
{
    private Object kameClone;
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

        if (kameClone == null)
            firing = false;
	}

    public override void Fire()
    {
        if(kameClone == null && totalEnergy > 0) 
        {
            kameClone = Instantiate(projectile, firingPosition.transform.position, Quaternion.identity);
            firing = true;
        }
    }

}
