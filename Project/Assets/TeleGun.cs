using UnityEngine;
using System.Collections;

public class TeleGun : MonoBehaviour {

	public float Cooldown;
	public GameObject Projectile;

	private float lastFireTime;

	private GameObject Player;
	private GameObject TeleProjectile;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (CooledDown (Cooldown))
		{
			if (TeleProjectile != null)
				TeleportTo (TeleProjectile);
			else if (Player != null)
				Fire ();
		}

	}

	bool CooledDown(float Cooldown)
	{
		lastFireTime += Time.deltaTime;

		if (lastFireTime > Cooldown)
		{
			lastFireTime = 0;
			return true;
		}

		return false;
	}

	void TeleportTo (GameObject obj)
	{
		this.transform.position = obj.transform.position;
		Destroy (obj);
	}

	void Fire()
	{
		TeleProjectile = (GameObject)Instantiate (Projectile, this.transform.position, Quaternion.identity);
		TeleProjectile.GetComponent<Telegunprojectile> ().SetTarget (Player.transform.position);
	}

	public void DestroyProjectile()
	{
		Destroy (TeleProjectile);
	}
}
