using UnityEngine;
using System.Collections;

public class MultiMissileLauncher : Weapon 
{
    private Enemy[] enemies;
    private int numberOfMissiles;
    public int Ammo = 10;

	// Use this for initialization
	void Start () 
    {
        firingPosition = GameObject.Find("WeaponSlot1");
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    override public void Fire()
    {
        enemies = GameObject.FindObjectsOfType<Enemy>();

        for (int i = 0; i < enemies.Length; i++)
        {
            numberOfMissiles++;
        }

        if (numberOfMissiles > 5)
            numberOfMissiles = 5;

        for (int i = 0; i < numberOfMissiles; i++)
        {
            if (Ammo > 0)
            {
                Instantiate(projectile, firingPosition.transform.position, Quaternion.identity);
                Ammo--;
            }
        }

        numberOfMissiles = 0;
    }
}
