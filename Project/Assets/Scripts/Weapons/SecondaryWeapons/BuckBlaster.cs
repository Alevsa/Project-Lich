using UnityEngine;
using System.Collections;

public class BuckBlaster : Weapon 
{
    public int Ammo;
    public GameObject Slug;
    private int slugs = 9, counter;
    private BuckBlasterProjectile slug;
    private Vector3 direction;

	void Start () 
    {
        firingPosition = GameObject.Find("WeaponSlot1");
	}
	
	void Update () {
	
	}

    override public void Fire()
    {
        for (int i = 0; i < slugs; i++)
        {
                Instantiate(Slug, firingPosition.transform.position, Quaternion.identity);  
        }
    }
}
