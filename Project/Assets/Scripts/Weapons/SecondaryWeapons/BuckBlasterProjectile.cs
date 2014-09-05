using UnityEngine;
using System.Collections;

public class BuckBlasterProjectile : Projectile
{
    private Vector3 direction;

    public BuckBlasterProjectile(Vector3 direction)
    {
        this.direction = direction;
    }
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

    public void StrafeUp()
    {
        movement += (direction * Time.deltaTime);
    }
}
