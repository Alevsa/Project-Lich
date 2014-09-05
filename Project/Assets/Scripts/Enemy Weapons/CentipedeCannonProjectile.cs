using UnityEngine;
using System.Collections;

public class CentipedeCannonProjectile : Projectile {

	public GameObject centipedeBomb;
	public float plantDistance;

	private Vector3 lastPlant;

	// Use this for initialization
	void Start () {
		lastPlant = transform.position;
	}
	
	// Update is called once per frame
	public override void Update () {
		DestroyAfterTime ();

		transform.Translate (Vector3.up * Time.deltaTime * Speed);

		if (Vector3.Distance (lastPlant, transform.position) >= plantDistance)
			PlantBomb ();
	}

	void PlantBomb () 
	{
		Instantiate (centipedeBomb, transform.position, Quaternion.identity);
		lastPlant = transform.position;
	}
}
