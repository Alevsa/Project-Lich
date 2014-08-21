using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public string Name;
	public float Cooldown;

    [HideInInspector]
	public GameObject firingPosition;

	public GameObject projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public virtual void Fire () {
	}

	public virtual void StopFire() {
	}
}
