using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public string kevin = "Hello Kevin";
	public string Name;
	public float Speed;
	public int Health;
	public string Type;
	public float Difficulty;
	public int Bounty;

	public GameObject EquippedWeapon;

    public GameObject DeathExplosion, damageExplosion;

	[HideInInspector]
	public Vector3 movement;
    [HideInInspector]
    public bool lockedOn;

	// Use this for initialization
	void Start () {
		EquipWeapon ();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (Health <= 0)
			Die ();

		GetPosition ();
		SetDestination ();
		Move();
	
		if (CheckFire ())
			Fire ();
	}

	public virtual void EquipWeapon () {
		if (EquippedWeapon != null) 
		{
			EquippedWeapon = GameObject.Instantiate (EquippedWeapon, this.transform.position, Quaternion.identity) as GameObject;
			EquippedWeapon.transform.parent = this.transform;
		}
	}

	public void GetPosition (){
		movement = transform.position;
	}

	public virtual void Move() {
		//float Length = Vector3.Distance (transform.position, movement);
		transform.position = movement;//Vector3.Lerp (transform.position, movement, Time.deltaTime * Speed / Length);
	}

	public virtual void SetDestination () {
		StrafeDown ();
	}

	public virtual bool CheckFire () {
		return false;
	}

	public virtual void Fire() {
	}

	public virtual void Die () {
        Instantiate(DeathExplosion, this.transform.position, Quaternion.identity);
        if(GameObject.Find("Player") != null)
            GameObject.Find ("Player").SendMessage ("AddScore", Bounty);
		Destroy (this.gameObject);
	}

	public void StrafeDown () {
		movement += (new Vector3 (0, -Speed, 0) * Time.deltaTime);
	}

	public virtual void ApplyDamage (int damage) 
    {
		Health -= damage;
	}

    public void SpawnExplosion(Vector3 explosionPosition)
    {
        if(Health > 0)
            Instantiate(damageExplosion, explosionPosition, Quaternion.identity);
    }

	public virtual void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.SendMessage("ApplyDamage", Health);
			Die ();
		}
	}
}
