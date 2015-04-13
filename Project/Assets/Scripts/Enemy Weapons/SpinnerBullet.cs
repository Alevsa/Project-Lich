using UnityEngine;
using System.Collections;

public class SpinnerBullet : Projectile {

	// Use this for initialization
	void Start () {
		Debug.Log (transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		move ();
		DestroyAfterTime();
	}

	private void move()
	{
		GetComponent<Rigidbody2D> ().velocity = transform.position * Speed;
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
