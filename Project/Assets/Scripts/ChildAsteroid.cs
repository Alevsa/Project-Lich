using UnityEngine;
using System.Collections;

public class ChildAsteroid : Enemy 
{
    private float speedX, speedY;
    public float LifeTime;

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

        StartCoroutine(Destroy());
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

}
