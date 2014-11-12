using UnityEngine;
using System.Collections;

public class Explosion : Projectile 
{
	void Start () 
    {
	
	}

	public override void Update () 
    {
	
	}

    public override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("ApplyDamage", Damage);
            Die();
        }
    }
}
