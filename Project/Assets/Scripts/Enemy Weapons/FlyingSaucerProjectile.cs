    using UnityEngine;
using System.Collections;

public class FlyingSaucerProjectile : Projectile 
{
    private Vector3 player;
    private Vector3 direction;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("Player").transform.position;
        direction = player - transform.position;
        direction.Normalize();
	}
	
	// Update is called once per frame
	public override void Update () 
    {
        FireAtPlayer();
        DestroyAfterTime();
	}

    void FireAtPlayer()
    {
        rigidbody2D.velocity = direction * Speed;
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
