using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public string Name;
	public float Speed;
	public int Health;

	[HideInInspector]
	public Vector3 movement;
    [HideInInspector]
    public bool lockedOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (Health <= 0)
			Die ();

		GetPosition ();
		SetDestination ();
		Move ();
	}

	public void GetPosition (){
		movement = transform.position;
	}

	public void Move() {
		//float Length = Vector3.Distance (transform.position, movement);
		transform.position = movement;//Vector3.Lerp (transform.position, movement, Time.deltaTime * Speed / Length);
	}

	public virtual void SetDestination () {
		StrafeDown ();
	}

	public void Die () {
		Destroy (this.gameObject);
	}

	public void StrafeDown () {
		movement += (new Vector3 (0, -Speed, 0) * Time.deltaTime);
	}

	public void ApplyDamage (int damage) {
		Health -= damage;
	}

	public virtual void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.SendMessage("ApplyDamage", Health);
			Die ();
		}
	}
}
