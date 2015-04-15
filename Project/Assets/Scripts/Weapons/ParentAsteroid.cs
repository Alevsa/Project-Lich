using UnityEngine;
using System.Collections;

public class ParentAsteroid : MonoBehaviour {

    public GameObject[] childAsteroids;
    public GameObject[] pickUps;
    public float LifeTime;
    private float speedX, speedY;
	public float Speed;

    private Vector3 centre;
    private Vector3 direction;

	public int Health;
	public int Bounty;
	public GameObject DeathExplosion, DamageExplosion;

	void Start () 
    {
        centre = GameObject.Find("Main Camera").transform.position;
        direction = (centre - new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f))) - transform.position;
        direction.Normalize();
	    //speedX = -1;
       // speedY = -1;
	}

    public void Update()
    {
        if (Health <= 0)
            Die();

        //GetPosition();
        AsteroidFloat();
        //Move();

        StartCoroutine(Destroy());
    }

    public void Die()
    {
        for (int i = 0; i < Random.Range(2, 4); i++)
            Instantiate(childAsteroids[i], transform.position, Quaternion.identity);

        float dropPickup = Random.Range(0f, 100f);
        if (dropPickup < 75f) {
			float firstDrop = Random.Range (0f, 100f);
			if (firstDrop < 60f)
				Instantiate (pickUps [0], transform.position, Quaternion.identity);
			else
				Instantiate (pickUps [Random.Range (1, pickUps.Length)], transform.position, Quaternion.identity);
		}

        Death ();
    }

	public void Death(){
			Instantiate(DeathExplosion, this.transform.position, Quaternion.identity);
			if(GameObject.Find("Player") != null)
				GameObject.Find ("Player").SendMessage ("AddScore", Bounty);
			Destroy (this.gameObject);
	}

    public void AsteroidFloat()
    {
        //movement += (new Vector3(speedX, speedY, 0) * Time.deltaTime);
        GetComponent<Rigidbody2D>().velocity = direction  * Speed;
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(this.gameObject);
    }

	public void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.SendMessage("ApplyDamage", Health);
			Die ();
		}
	}

	public virtual void ApplyDamage (int damage) 
	{
		Health -= damage;
	}
	
	public void SpawnExplosion(Vector3 explosionPosition)
	{
		if(Health > 0)
			Instantiate(DamageExplosion, explosionPosition, Quaternion.identity);
	}
}
