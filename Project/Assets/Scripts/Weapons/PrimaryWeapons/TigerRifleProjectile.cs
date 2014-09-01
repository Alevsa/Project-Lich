using UnityEngine;
using System.Collections;

public class TigerRifleProjectile : Projectile 
{
    public int enemiesHit;
    private int hitCounter;
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

        if (hitCounter >=    enemiesHit)
            Die();
	}

    public override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            hitCounter++;
            coll.gameObject.SendMessage("ApplyDamage", Damage);
            coll.gameObject.SendMessage("SpawnExplosion", transform.position);
        }
        
    }
}
