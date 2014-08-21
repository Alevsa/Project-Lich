using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {

	public int PlayerID;
	public int Health;
	public int MaxHealth;
	public int Lives;


	public bool invulnerable;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Health <= 0)
			Die ();
	}

	void Die () {
		Destroy (this.gameObject);
		Application.Quit ();
	}

	void ApplyDamage (int damage) 
    {
        if (!invulnerable)
        {
            Health -= damage;
        }
	}

    void Invulnerable(bool invuln)
    {
        if (invuln)
            invulnerable = true;
        else
            invulnerable = false;
    }
}
