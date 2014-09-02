using UnityEngine;
using System.Collections;

public class DoubleTigerRifle : Weapon
{

	// Use this for initialization
	void Start () 
    {
        firingPosition = GameObject.Find("WeaponSlot1");    
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public override void Fire()
    {
        StartCoroutine(FireDouble());
    }

    IEnumerator FireDouble()
    {
        Instantiate(projectile, firingPosition.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(projectile, firingPosition.transform.position, Quaternion.identity);
    }
}
