using UnityEngine;
using System.Collections;

public class Missile : Projectile 
{
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        GetPosition();
        StrafeUp();
        Move();
        DestroyAfterTime();
	}

    public override void Die()
    {
        Destroy(this.gameObject);
    }

    public override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("ApplyDamage", Damage);
            Instantiate(ProjectileExplosion, this.transform.position, Quaternion.identity);
            Die();
        }
    }     
}
