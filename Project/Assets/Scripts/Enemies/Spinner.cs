using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {

	public float baseRotSpeed, speedToFire, incSpeed;
	private float speed;
	private bool firing;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * (speed * Time.deltaTime));

		if (firing)
			speed += (Time.deltaTime * incSpeed);
		if (speed > speedToFire)
			fire ();
		if (!firing && speed > baseRotSpeed)
			speed -= (Time.deltaTime * incSpeed);

	}

	public void startFire()
	{
		firing = true;
	}

	private void fire()
	{
		firing = false;
	}

}
