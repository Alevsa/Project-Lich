using UnityEngine;
using System.Collections;

public class Hummingbird : Enemy {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public override void Update () {
		if (Health <= 0)
			Die ();
	}

	public override void Die() {
		GetComponent<TeleGun> ().DestroyProjectile ();

		Instantiate(DeathExplosion, this.transform.position, Quaternion.identity);
		if(GameObject.Find("Player") != null)
			GameObject.Find ("Player").SendMessage ("AddScore", Bounty);
		Destroy (this.gameObject);
	}
}
