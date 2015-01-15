using UnityEngine;
using System.Collections;

public class LionCannon : Weapon {

	// Use this for initialization
	void Start ()  {
		unbound = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (unbound)
		{
			foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
			{
				if (player.GetComponent<Controls>().playerNumber == BelongsToPlayer)
				{
					firingPosition = player.transform.GetChild(0).gameObject;
					unbound = false;
				}
			}
		}
	}

	override public void Fire ()
	{
		Instantiate (projectile, firingPosition.transform.position + new Vector3(Random.Range(-0.1F,0.1F), 0,0), Quaternion.identity);
	}
}
