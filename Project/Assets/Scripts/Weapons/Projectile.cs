using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int Damage;
	public float Speed;

    public float TimeTillDestroyed = 3;
    private float timer;

	[HideInInspector]
	public Vector3 movement;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
    {
       
	}

	public void GetPosition () {
		movement = transform.position;
	}

	public void Move() {
		transform.position = movement;
	}

	public void Die () {
		Destroy (this.gameObject);
	}

    public void DestroyAfterTime()
    {
        timer += Time.deltaTime;
        if (timer > TimeTillDestroyed)
            Die();
    }

	public void StrafeUp () {
		movement += (new Vector3 (0, Speed, 0) * Time.deltaTime);
	}

	public void StrafeDown () {
		movement += (new Vector3 (0, -Speed, 0) * Time.deltaTime);
	}

	public virtual void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Enemy")
		{
			coll.gameObject.SendMessage ("ApplyDamage", Damage);
            coll.gameObject.SendMessage ("SpawnExplosion", transform.position);
			Die ();
		}
	}

}
