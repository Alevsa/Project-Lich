using UnityEngine;
using System.Collections;

public class MultiMissileLauncher : Weapon 
{
    public int NumberOfMissiles;

	// Use this for initialization
	void Start () 
    {
        firingPosition = GameObject.Find("WeaponSlot1");
	}
	
	// Update is called once per frame
	void Update () 
    {
        for (int i = 0; i < NumberOfMissiles; i++)
        {
          Instantiate(projectile, firingPosition.transform.position, Quaternion.identity);
        }
	}
}
