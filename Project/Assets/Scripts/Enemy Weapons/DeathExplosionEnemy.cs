using UnityEngine;
using System.Collections;

public class DeathExplosionEnemy : MonoBehaviour 
{
	public int Damage;
	public float ExplosionTime;
	private float timer;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if(timer > ExplosionTime)
			Destroy(gameObject);
	}

	public virtual void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.SendMessage ("ApplyDamage", Damage);
		}
	}
	
}
