using UnityEngine;
using System.Collections;

public class FlyingSaucerWeapon : Weapon 
{
    private GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Fire()
    {
        player = null;
        player = GameObject.Find("Player");
        if(player != null)
            Instantiate(projectile, this.transform.position, Quaternion.identity);
    }
}
