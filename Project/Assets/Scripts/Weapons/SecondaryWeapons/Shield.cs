using UnityEngine;
using System.Collections;

public class Shield : Projectile {

	public GameObject damageExplosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public override void Update () {
	
	}

    public override void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.gameObject.tag == "Projectile")
			Destroy(coll.gameObject);
		if (coll.gameObject.tag == "Enemy")
			coll.gameObject.SendMessage("ApplyDamage", Damage);
    }

	public void SpawnExplosion(Vector3 explosionPosition)
	{
		Instantiate(damageExplosion, explosionPosition, Quaternion.identity);
	}
}
