using UnityEngine;
using System.Collections;

public class CheetahProjectile : Projectile 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetPosition();
        StrafeUp();
        Move();
        DestroyAfterTime();
	}
}
