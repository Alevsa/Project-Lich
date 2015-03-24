using UnityEngine;
using System.Collections;

public class ParentAsteroid : Enemy {

    public GameObject[] childAsteroids;
    public GameObject[] pickUps;
    public float LifeTime;
    private float speedX, speedY;

    private Vector3 centre;
    private Vector3 direction;

	void Start () 
    {
        centre = GameObject.Find("Main Camera").transform.position;
        direction = (centre - new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f))) - transform.position;
        direction.Normalize();
	    //speedX = -1;
       // speedY = -1;
	}

    public override void Update()
    {
        if (Health <= 0)
            Die();

        //GetPosition();
        AsteroidFloat();
        //Move();

        StartCoroutine(Destroy());
    }

    public override void Die()
    {
        for (int i = 0; i < Random.Range(3, 6); i++)
            Instantiate(childAsteroids[i], transform.position, Quaternion.identity);

        float dropPickup = Random.Range(0f, 100f);
        if (dropPickup < 50f) {
			float firstDrop = Random.Range (0f, 100f);
			if (firstDrop < 60f)
				Instantiate (pickUps [0], transform.position, Quaternion.identity);
			else
				Instantiate (pickUps [Random.Range (1, pickUps.Length)], transform.position, Quaternion.identity);
		}

        base.Die();
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
}
