﻿using UnityEngine;
using System.Collections;

public class Explosion : Projectile 
{
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("ApplyDamage", Damage);
            Die();
        }
    }
}
