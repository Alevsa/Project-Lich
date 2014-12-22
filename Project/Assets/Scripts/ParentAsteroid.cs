using UnityEngine;
using System.Collections;

public class ParentAsteroid : Enemy {

    public GameObject[] childAsteroids;
    private GameObject spawnPoint;
    private float speedX, speedY;

	// Use this for initialization
	void Start () 
    {
	     speedX = -1;
         speedY = -1;
	}

    public override void Update()
    {
        if (Health <= 0)
            Die();

        GetPosition();
        AsteroidFloat();
        Move();
    }

    public override void Die()
    {
        for (int i = 0; i < Random.Range(3, 6); i++)
            Instantiate(childAsteroids[i], transform.position, Quaternion.identity);

        base.Die();
    }

    public void AsteroidFloat()
    {
        movement += (new Vector3(speedX, speedY, 0) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "LevelBorder")
        {
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this);
    }
}
