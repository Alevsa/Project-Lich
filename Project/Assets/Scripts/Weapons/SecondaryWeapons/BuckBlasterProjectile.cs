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
	public override void Update () 
    {
        GetPosition();
        StrafeUp1();
        Move();
        DestroyAfterTime();
	}

    public void StrafeUp1()
    {
        movement += (direction * Time.deltaTime);
    }
}
