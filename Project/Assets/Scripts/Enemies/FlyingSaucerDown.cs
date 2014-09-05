using UnityEngine;
using System.Collections;

public class FlyingSaucerDown : MonoBehaviour 
{
    private Vector3 movement;
    public float Speed;
    private GameObject flyingSaucer;

	// Use this for initialization
	void Start () 
    {
        flyingSaucer = transform.GetChild(0).gameObject;
	}

    void Update()
    {
        GetPosition();
        SetDestination();
        Move();

        if (flyingSaucer == null)
            Destroy(gameObject);
    }

    public void GetPosition()
    {
        movement = transform.position;
    }

    public void Move()
    {
        transform.position = movement;
    }

    public virtual void SetDestination()
    {
        StrafeDown();
    }

    public void StrafeDown()
    {
        movement += (new Vector3(0, -Speed, 0) * Time.deltaTime);
    }
}
