using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {

	public int PlayerID;
	public int Health;
	public int MaxHealth;
	public int Lives;
	public int Score;

    public GameObject DeathExplosion, damageExplosion;
	public bool invulnerable;

    private GameObject menu;

	// Use this for initialization
	void Start () 
    {
        menu = GameObject.Find("Menu");
        menu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if (Health <= 0)
			Die ();
	}

	void Die () 
    {
        Instantiate(DeathExplosion, this.transform.position, Quaternion.identity);
		Destroy (this.gameObject);
        GameObject.Find("Fader").GetComponent<FadeOut>().fadeOutScene();
        menu.SetActive(true);
	}

	void ApplyDamage (int damage) 
    {
        if (!invulnerable)
        {
            Health -= damage;
        }
	}

    public void SpawnExplosion(Vector3 explosionPosition)
    {
        if (Health > 0)
            Instantiate(damageExplosion, explosionPosition, Quaternion.identity);
    }

	public void AddScore(int amount)
	{
		Score += amount;
	}


    void Invulnerable(bool invuln)
    {
        invulnerable = invuln;
    }
}
