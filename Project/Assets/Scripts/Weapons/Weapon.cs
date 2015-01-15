using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public string Name;
    public string Group;
	public string Type;
	public float Cooldown;
    public float Ammo;
	public bool onCooldown;
	public GameObject Upgrade;
	public int BelongsToPlayer;

	public bool unbound = false;

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
