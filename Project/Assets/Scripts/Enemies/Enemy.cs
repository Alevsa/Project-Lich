using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public string Name;
	public float Speed;
	public int Health;

	[HideInInspector]
	public Vector3 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (Health <= 0)
			Die ();

		GetPosition ();
		Move ();
	}

	public void GetPosition (){
		movement = transform.position;
	}

	public void Move() {
		float Length = Vector3.Distance (transform.position, movement);
		transform.position = Vector3.Lerp (transform.position, movement, Time.deltaTime * Speed / Length);
	}

	public void Die () {
		Destroy (this.gameObject);
	}

	public void StrafeDown () {
		movement += new Vector3 (0, -Speed, 0);
	}
}
