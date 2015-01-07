using UnityEngine;
using System.Collections;

public class PickupWeapon : MonoBehaviour {

	public string Category;
	public GameObject weapon;
    public float Speed;
    private Vector3 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetPosition();
        SetDestination();
        Move();
	}

    public void GetPosition()
    {
        movement = transform.position;
    }

    public virtual void Move()
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

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			coll.gameObject.SendMessage ("ChangeWeapon", weapon);
			Destroy (this.gameObject);
		}
	}
}
