using UnityEngine;
using System.Collections;

public class BananaProjectile : Projectile {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetPosition();
        StrafeUp();
        Move();
        DestroyAfterTime();
	}

    public override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("ApplyDamage", Damage);
            coll.gameObject.SendMessage("SpawnExplosion", transform.position);
        }

        if (coll.gameObject.tag == "Projectile")
        {
            Destroy(coll.gameObject);
        }
    }
}
