using UnityEngine;
using System.Collections;

public class Explosion : Projectile 
{
	private float timer;

	void Start () 
    {
		timer = 0f;
	}

	public override void Update () 
    {
		timer += Time.deltaTime;

		if (timer > 0.5f)
			Die ();
	}

    public override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
            coll.gameObject.SendMessage("ApplyDamage", Damage);;
    }
	
}
