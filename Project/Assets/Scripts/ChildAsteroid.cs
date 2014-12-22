using UnityEngine;
using System.Collections;

public class ChildAsteroid : Enemy 
{
    private float speedX, speedY;

	void Start () 
    {
        int direction = Random.Range(1, 4);
        DetermineDirection(direction);
	}

    public override void Update()
    {
        if (Health <= 0)
            Die();

        GetPosition();
        AsteroidFloat();
        Move();
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
                speedX = -1;
                speedY = -1;
                break;
            case 2:
                speedX = -1;
                speedY = 1;
                break;
            case 3:
                speedX = 1;
                speedY = -1;
                break;
            case 4:
                speedX = 1;
                speedY = 1;
                break;
        }
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
