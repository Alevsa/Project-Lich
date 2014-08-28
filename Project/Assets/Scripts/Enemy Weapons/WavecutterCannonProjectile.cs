using UnityEngine;
using System.Collections;

public class WavecutterCannonProjectile : Projectile {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GetPosition ();
		StrafeDown ();
		Move ();
        DestroyAfterTime();

	}

	public override void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") 
        {
				coll.gameObject.SendMessage ("ApplyDamage", Damage);
                coll.gameObject.SendMessage("SpawnExplosion", transform.position);
				Die ();
		}
	}
}
