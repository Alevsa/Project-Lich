using UnityEngine;
using System.Collections;

public class SpinnerBullet : Projectile {

	public Vector3 direction;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		move ();
		DestroyAfterTime();
	}

	private void move()
	{
		GetComponent<Rigidbody2D> ().velocity = direction * Speed;
	}

	public override void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.SendMessage("ApplyDamage", Damage);
			coll.gameObject.SendMessage("SpawnExplosion", transform.position);
			Die();
		}
	}
}
