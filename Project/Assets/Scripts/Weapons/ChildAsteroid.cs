using UnityEngine;
using System.Collections;

public class ChildAsteroid : MonoBehaviour 
{
    private float speedX, speedY;
    public float LifeTime;
	public Vector3 movement;

	public int Bounty;
	public GameObject DeathExplosion, DamageExplosion;
	public int Health;

	void Start () 
    {
        int direction = Random.Range(1, 4);
        DetermineDirection(direction);
	}

    public void Update()
    {
        if (Health <= 0)
            Die();

        GetPosition();
        AsteroidFloat();
        Move();

        StartCoroutine(Destroy());
    }

	public void Move() {
		//float Length = Vector3.Distance (transform.position, movement);
		transform.position = movement;//Vector3.Lerp (transform.position, movement, Time.deltaTime * Speed / Length);
	}


	public void GetPosition (){
		movement = transform.position;
	}

    public void AsteroidFloat()
    {
        movement += (new Vector3(speedX, speedY, 0) * Time.deltaTime);
    }

    public void DetermineDirection(int direction)
    {
        switch (direction)
        {
            case 1:
                speedX = -(Random.Range(0.5f, 1.5f));
                speedY = -(Random.Range(0.5f, 1.5f));
                break;
            case 2:
                speedX = -(Random.Range(0.5f, 1.5f));
                speedY = (Random.Range(0.5f, 1.5f));
                break;
            case 3:
                speedX = (Random.Range(0.5f, 1.5f));
                speedY = -(Random.Range(0.5f, 1.5f));
                break;
            case 4:
                speedX = (Random.Range(0.5f, 1.5f));
                speedY = (Random.Range(0.5f, 1.5f));
                break;
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(this.gameObject);
    }

	public void Die () {
		Instantiate(DeathExplosion, this.transform.position, Quaternion.identity);
		if(GameObject.Find("Player") != null)
			GameObject.Find ("Player").SendMessage ("AddScore", Bounty);
		Destroy (this.gameObject);
	}

	public virtual void OnTriggerEnter2D (Collider2D coll) {
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
