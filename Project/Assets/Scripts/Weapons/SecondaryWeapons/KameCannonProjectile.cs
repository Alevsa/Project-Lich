using UnityEngine;
using System.Collections;

public class KameCannonProjectile : Projectile 
{
	private BoxCollider2D col;
	public float growRate, moveRate, maxY, moveY;
	private float curHeight, curPos;
	private Vector3 pos, size;

	// Use this for initialization
	void Start () 
	{
		col = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	public override void Update ()
    {
		moveCollider ();
    }

	private void moveCollider()
	{
		if (curPos <= moveY)
		{
			pos = col.transform.position;
			pos.y += moveRate;
			col.transform.position = pos;
			curPos = pos.y;
		}

		if (curHeight <= maxY)
		{
			size = col.size;
			size.y += growRate;
			col.size = size;
			curHeight = size.y;
		}
	}

    public override void OnTriggerEnter2D(Collider2D coll)
	{
        if (coll.gameObject.tag == "Enemy")
            coll.gameObject.SendMessage("ApplyDamage", Damage);
    }
}
