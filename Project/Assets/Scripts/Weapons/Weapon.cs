using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public string Name;
	public float Cooldown;

	public Vector3 firingPosition;
	public Projectile projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public virtual void Fire () {
	}
}
