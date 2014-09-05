using UnityEngine;
using System.Collections;

public class CentipedeCannon : Weapon {

	private GameObject liveProjectile;
	private GameObject liveProjectile2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((liveProjectile == null) && (liveProjectile2 == null))
			Fire ();
	
	}

	public override void Fire()
	{
		liveProjectile = GameObject.Instantiate (projectile, this.transform.position, Quaternion.identity) as GameObject;
		liveProjectile.transform.rotation = transform.rotation;
		liveProjectile.transform.Rotate (0, 0, 90);

		liveProjectile2 = GameObject.Instantiate (projectile, this.transform.position, Quaternion.identity) as GameObject;
		liveProjectile2.transform.rotation = transform.rotation;
		liveProjectile2.transform.Rotate (0, 0, -90);
	}
}
