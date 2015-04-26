using UnityEngine;
using System.Collections;

public class Telegunprojectile : Projectile {

	private Vector3 Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public override void Update () {
		if (Target != null)
			this.transform.position = Vector3.MoveTowards (this.transform.position, Target, Speed * Time.deltaTime);
	}

	public void SetTarget(Vector3 tar)
	{
		Target = tar + (tar - this.transform.position).normalized;
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
