﻿using UnityEngine;
using System.Collections;

public class Missile : Projectile 
{
    public GameObject explosion;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	public override void Update () {
        GetPosition();
        StrafeUp();
        Move();
        DestroyAfterTime();
	}

    public override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("ApplyDamage", Damage);
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Die();
        }
    }     
}
