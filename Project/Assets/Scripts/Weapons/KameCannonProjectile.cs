using UnityEngine;
using System.Collections;

public class KameCannonProjectile : Projectile 
{
    private KameCannon kameCannon;

	// Use this for initialization
	void Start () 
    {
        kameCannon = GameObject.Find("KameCannon(Clone)").GetComponent<KameCannon>();
        this.transform.parent = GameObject.Find("KameCannon(Clone)").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonUp("Space"))
            Destroy(gameObject);

        if (kameCannon.totalEnergy <= 0)
            Destroy(gameObject);

    }
}
