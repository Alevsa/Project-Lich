using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultiMissileLauncher : Weapon 
{
    private Enemy[] enemies;
    private int numberOfMissiles;
	private List<float[]> direction;

	// Use this for initialization
	void Start () 
    {
        firingPosition = GameObject.Find("WeaponSlot1");
		direction = new List<float[]>();
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

		Cooldown = numberOfMissiles * 0.3f + 0.3f;
		generateDirections ();
		fireMissiles ();

        numberOfMissiles = 0;
    }

	private void fireMissiles()
	{
		for (int i = 0; i < numberOfMissiles; i++)
		{
			if (Ammo > 0)
			{
				GameObject projClone = Instantiate(projectile, firingPosition.transform.position, Quaternion.identity) as GameObject;
				projClone.SendMessage("fallDirection", direction[i]);
				Ammo--;
                GetComponent<AudioSource>().Play();
			}
		}

		direction.Clear();
	}

	private void generateDirections()
	{
		for (int i = 0; i < numberOfMissiles; i++) 
		{
			float xDirection = Random.Range(-2, 2f);
			float yDirection = Random.Range(-2f, 2f);
			float[] dir = {xDirection, yDirection};
			direction.Add(dir);
		}

	}
}
